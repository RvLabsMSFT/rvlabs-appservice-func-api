var express = require('express');
var router = express.Router();
var apiAdapter = require('./apiAdapter');

const BASE_URL = 'https://rvlabs-echo-api.azurewebsites.net'
const api = apiAdapter(BASE_URL)

const options = {
  headers: {'x-functions-key': ''}
};

/* GET users listing. */
router.get('/echo', function(req, res, next) {
  res.send('TXT ECHO API -- ' + JSON.stringify(req.headers));
});

router.post('/api/echo_api', (req, res) => {
  
  console.log(JSON.stringify(req))

  api.post(req.path, req.body, options)
  .then(resp => {
    console.log(JSON.stringify(resp))
    res.send(resp.data)
  })
  .catch(error => {
    console.log('Error on backend')
    res.send(JSON.stringify(error))
  })
})

module.exports = router;
