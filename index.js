const PORT = process.env.scsToken || 1234

const ejs = require('ejs')
const cors = require('cors')
const path = require('path').resolve()
const chalk = require('chalk')
const express = require('express')

const data = [[], [], []]
const offlineSW = [[], [], []]
const app = express()
app.use(cors())
app.use(express.text({ limit: '100MB' }))

setInterval(() => {
  data.forEach((grade, i1) => {
    grade.forEach((_room, i2) => {
      if (!offlineSW[i1][i2]) data[i1][i2] = ''
      else offlineSW[i1][i2] = false
    })
  })
}, 30000)

app.get('/', (_req, res) => res.redirect('/view'))
app.get('/view', (req, res) => {
  console.log(chalk.bgBlue.black('[webGet] by ' + req.ip))
  ejs.renderFile(path + '/view/index.ejs', { data }, (err, str) => {
    if (err) console.log(err)
    res.send(str)
  })
})

app.get('/api/imgJson/:grade/:room', (req, res) => {
  const grade = req.params.grade
  const room = req.params.room
  console.log(chalk.bgBlue.black('[imgGet] ' + grade + '-' + room + ' by ' + req.ip))

  if (grade > 0 && room > 0 && grade < 4 && room < 13) {
    res.send(data[grade][room])
  } else res.sendStatus(404)
})

app.put('/api/imgJson/:grade/:room/', (req, res) => {
  const grade = req.params.grade
  const room = req.params.room
  console.log(chalk.bgGreen.black('[imgPut] ' + grade + '-' + room + ' by ' + req.ip))
  offlineSW[grade][room] = true

  if (grade > 0 && room > 0 && grade < 4 && room < 13) {
    data[grade][room] = req.body
    res.sendStatus(200)
  } else res.sendStatus(404)
})

app.listen(PORT, () => {
  console.log(chalk.black.bgYellow('School Computer Security Server is now on http://localhost:') + chalk.black.bgYellow.bold(PORT))
})
