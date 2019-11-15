const PORT = process.env.scsToken || 1234

const fs = require('fs')
const ejs = require('ejs')
const cors = require('cors')
const path = require('path').resolve()
const uuid = require('uuid/v4')
const chalk = require('chalk')
const express = require('express')
const { JsonFile } = require('jsonque')
const hashCrypto = require('./hashCrypto')
if (!hashCrypto) throw new Error('Crypyo JS File is not Exist at ' + path + '/hashCrypto.js')

if (!fs.existsSync(path + '/data/')) fs.mkdirSync(path + '/data')

const app = express()
const auths = []
const imgData = [[], [], []]
const mgrData = [[], [], []]
const offlineSW = [[], [], []]
const macData = new JsonFile(path + '/data/macJson.json')
macData.read((str) => { if (!str) macData.write([]) })

app.use(cors())
app.use(express.text({ limit: '100MB' }))

setInterval(() => {
  imgData.forEach((grade, i1) => {
    grade.forEach((_room, i2) => {
      if (!offlineSW[i1][i2]) imgData[i1][i2] = ''
      else offlineSW[i1][i2] = false
    })
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

// }

// Mac Address {
app.get('/api/macJson/:mac', (req, res) => {
  const { mac } = req.params
  console.log(chalk.bgBlue.black('[macGet] by' + req.ip))

  macData.read((macs) => {
    if (!macs[mac]) res.send('Fail')
    else res.send([macs[mac].imgJson, macs[mac].mgrJson].join(';'))
  })
})

app.get('/api/macJson/:grade/:room/:mac', (req, res) => {
  const { grade, room, mac } = req.params
  console.log(chalk.bgGreen.black('[macPut] by ' + req.ip))

  macData.read((str) => {
    if (!str[mac]) {
      str[mac] = {
        imgJson: '/api/imgJson/' + grade + '/' + room,
        mgrJson: '/api/mgrJson/' + grade + '/' + room
      }

      macData.write(str, () => { res.sendStatus(200) })
    } else res.sendStatus(200)
  })
})
// }

// Auth {
app.get('/api/auth/genUUID/:grade/:room/:passwd', (req, res) => {
  const { grade, room, passwd } = req.params

  if (hashCrypto(grade, room, passwd)) {
    const id = uuid()
    auths[auths.length] = id
    res.send({ correct: true, path: '/grade' + grade + '/room' + room + '/' + id })
  } else {
    res.send({ correct: false })
  }
})
// }

// Viewer {
app.get('/:grade/:room/:id', (req, res) => {
  let { grade, room, id } = req.params

  grade = grade.replace('grade', '')
  room = room.replace('room', '')

  if (auths.includes(id)) {
    const newid = uuid()
    auths[auths.indexOf(id)] = newid
    ejs.renderFile(path + '/view/viewer.ejs', { grade, room, id }, (err, str) => {
      if (err) console.log(err)
      res.send(str)
    })
  } else res.redirect('/view')
})
// }

// 포트에서 값을 읽어옴 {
app.listen(PORT, () => {
  console.log(chalk.black.bgYellow('School Computer Security Server is now on http://localhost:') + chalk.black.bgYellow.bold(PORT))
})
// }
