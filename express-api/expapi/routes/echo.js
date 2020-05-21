var express = require('express');
var router = express.Router();
var apiAdapter = require('./apiAdapter');

const BASE_URL = 'http://localhost:7071'
const api = apiAdapter(BASE_URL)

/* GET users listing. */
router.get('/echo', function(req, res, next) {
  res.send('respond with a ECHO API');
});

router.post('/api/echo_api', (req, res) => {
  api.post(req.path, req.body).then(resp => {
    res.send(resp.data)
  })
})

module.exports = router;
