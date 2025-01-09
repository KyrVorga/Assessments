//SETUP - Modules
var express = require('express');
var router = express.Router();

//SETUP - Import Routes
const all = require('./all')
const create = require('./create')


router.use('/', all);
router.use('/', create);


module.exports = router;