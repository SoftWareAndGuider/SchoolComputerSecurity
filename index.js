const PORT = process.env.scsToken || 1234

const fs = require('fs')
const ejs = require('ejs')
const cors = require('cors')
const path = require('path').resolve()
const uuid = require('uuid/v4')
const chalk = require('chalk')
const express = require('express')
const hashCrypto = require('./hashCrypto')

if (!fs.existsSync(path + '/data/')) fs.mkdirSync(path + '/data')
if (!fs.existsSync(path + '/data/macJson.json')) fs.writeFileSync(path + '/data/macJson.json', '{}')
const macData = require(path + '/data/macJson.json')

const app = express()
const auths = []
const imgData = [null, [], [], []]
const mgrData = [null, [], [], []]
const offlineSW = [null, [], [], []]

app.use(cors())
app.use(express.text({ limit: '100MB' }))

setInterval(() => {
  imgData.forEach((grade, i1) => {
    if (grade) {
      grade.forEach((_room, i2) => {
        if (!offlineSW[i1][i2]) imgData[i1][i2] = ''
        else offlineSW[i1][i2] = false
      })
    }
  })
}, 30000)

// 웹페이지 부분 {
app.get('/', (_req, res) => res.redirect('/view'))
app.get('/view', (req, res) => {
  console.log(chalk.bgBlue.black('[webGet] by ' + req.ip))
  ejs.renderFile(path + '/view/index.ejs', (err, str) => {
    if (err) console.log(err)
    res.send(str)
  })
})

// }

// Base64 JSON {
app.get('/api/imgJson/:grade/:room', (req, res) => {
  const { grade, room } = req.params
  console.log(chalk.bgBlue.black('[imgGet] ' + grade + '-' + room + ' by ' + req.ip))
  res.send(imgData[grade][room])
})

app.put('/api/imgJson/:grade/:room', (req, res) => {
  const grade = req.params.grade
  const room = req.params.room
  console.log(chalk.bgGreen.black('[imgPut] ' + grade + '-' + room + ' by ' + req.ip))
  offlineSW[grade][room] = true
  imgData[grade][room] = req.body

  res.sendStatus(200)
})

// }

// 시스템 종료, 절전 관리 {
app.get('/api/mgrJson/:grade/:room', (req, res) => {
  const { grade, room } = req.params
  console.log(chalk.bgBlue.black('[mgrGet] ' + grade + '-' + room + ' by ' + req.ip))

  if (!mgrData[grade][room]) mgrData[grade][room] = [false, false, false, false, '', false, false]

  // [종료, 리붓, 절전, 메세지 유뮤, 메세지 내용, 명령, tm]]
  res.send(JSON.stringify(mgrData[grade][room]))
  mgrData[grade][room] = [false, false, false, false, '', mgrData[grade][room][5], mgrData[grade][room][6]]
})

app.put('/api/mgrJson/:grade/:room', (req, res) => {
  const { grade, room } = req.params
  console.log(chalk.bgGreen.black('[mgrPut] ' + grade + '-' + room + ' by ' + req.ip))

  if (!mgrData[grade][room]) mgrData[grade][room] = [false, false, false, false, '', false, false]

  mgrData[grade][room][5] = JSON.parse(req.body.split(';')[0])
  mgrData[grade][room][6] = JSON.parse(req.body.split(';')[1])
  res.sendStatus(200)
})

app.get('/api/mgrJson/:grade/:room/:proc', (req, res) => {
  const { grade, room, proc } = req.params
  console.log(chalk.bgBlue.black('[mgrGet] ' + grade + '-' + room + ' by ' + req.ip))

  if (!mgrData[grade][room]) mgrData[grade][room] = [false, false, false, false, '', false, false]

  switch (proc) {
    case 'shutdown':
      mgrData[grade][room][0] = true
      res.sendStatus(200)
      break

    case 'restart':
      mgrData[grade][room][1] = true
      res.sendStatus(200)
      break

    case 'powerSave':
      mgrData[grade][room][2] = true
      res.sendStatus(200)
      break

    default:
      res.sendStatus(404)
      break
  }
})

// }

// Message {
app.get('/api/msgJson/:grade/:room/:message', (req, res) => {
  const { grade, room, message } = req.params
  console.log(chalk.bgBlue.black('[msgGet] ' + grade + '-' + room + ' by ' + req.ip))

  if (!mgrData[grade][room]) mgrData[grade][room] = [false, false, false, false, '', mgrData[grade][room][5], mgrData[grade][room][6]]

  mgrData[grade][room][3] = true
  mgrData[grade][room][4] = message

  res.sendStatus(200)
})
// }

// Mac Address {
app.get('/api/macJson/:mac', (req, res) => {
  const { mac } = req.params
  console.log(chalk.bgBlue.black('[macGet] by' + req.ip))

  if (!macData[mac]) res.send('Fail')
  else res.send([macData[mac].imgJson, macData[mac].mgrJson, macData[mac].msgJson].join(';'))
})

app.get('/api/macJson/:grade/:room/:mac', (req, res) => {
  const { grade, room, mac } = req.params
  console.log(chalk.bgGreen.black('[macPut] ' + grade + '-' + room + ' by ' + req.ip))

  if (!macData[mac]) {
    macData[mac] = {
      imgJson: '/api/imgJson/' + grade + '/' + room,
      mgrJson: '/api/mgrJson/' + grade + '/' + room,
      msgJson: '/api/msgJson/' + grade + '/' + room
    }

    fs.writeFile(path + '/data/macJson.json', JSON.stringify(macData), (err) => {
      if (err) console.log(err)
      else res.sendStatus(200)
    })
  } else res.sendStatus(200)
})
// }

// Auth {
app.get('/api/auth/genUUID/:grade/:room/:passwd', (req, res) => {
  const { grade, room, passwd } = req.params
  console.log(chalk.bgMagenta.black('[uidReq] ' + grade + '-' + room + ' by ' + req.ip))

  if (hashCrypto(grade, room, passwd)) {
    const id = uuid()
    console.log(chalk.bgCyan.black('[uidGen] by ' + req.ip + ' to ' + id))
    auths[auths.length] = id
    res.send({ correct: true, path: '/grade' + grade + '/room' + room + '/' + id })
  } else {
    console.log(chalk.bgRed.black('[uidNeg] by ' + req.ip))
    res.send({ correct: false })
  }
})
// }

// Viewer {
app.get('/:grade/:room/:id', (req, res) => {
  let { grade, room, id } = req.params
  console.log(chalk.bgBlue.black('[webGet] ' + grade + '-' + room + ' by ' + req.ip + ' from ' + id))

  grade = grade.replace('grade', '')
  room = room.replace('room', '')

  if (auths.includes(id)) {
    const newid = uuid()
    auths[auths.indexOf(id)] = newid
    console.log(chalk.bgCyan.black('[uidGen] by ' + req.ip + ' from ' + id + ' to ' + newid))
    ejs.renderFile(path + '/view/viewer.ejs', { grade, room, newid }, (err, str) => {
      if (err) console.log(err)
      res.send(str)
    })
  } else {
    console.log(chalk.bgRed.black('[uidNeg] by ' + req.ip))
    res.redirect('/view')
  }
})
// }

// Debug {
app.get('/raw/:request', (req, res) => {
  const { request } = req.params
  console.log(chalk.bgBlue.black('[rawGet] by ' + req.ip + ' at ' + request))

  switch (request) {
    case 'auths':
      res.sendStatus(403)
      break

    case 'imgData':
      res.send(imgData)
      break

    case 'mgrData':
      res.send(mgrData)
      break

    case 'macData':
      res.send(macData)
      break

    case 'offlineSW':
      res.send(offlineSW)
      break

    default:
      res.sendStatus(404)
      break
  }
})
// }

// 포트에서 값을 읽어옴 {
app.listen(PORT, () => {
  console.log(chalk.black.bgYellow('School Computer Security Server is now on http://localhost:') + chalk.black.bgYellow.bold(PORT))
})
// }
