var express = require('express');
var router = express.Router()
var echoService = require('./routes/echo')

router.use((req, res, next) => {
    console.log("Called: ", req.path)
    next()
})

router.use(echoService)

module.exports = router