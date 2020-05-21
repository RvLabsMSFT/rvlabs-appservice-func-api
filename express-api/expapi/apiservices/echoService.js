var express = require('express');
var router = express.Router()

router.post('/echo', (req, res) => {
    res.send(req.path + " called")
})

module.exports = router