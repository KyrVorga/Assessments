//SETUP - Modules
var express = require('express');
var router = express.Router();

//SETUP - Import Routes
const all = require('./all')
const create = require('./create')
const redeem = require('./redeem')


router.use('/', all);
router.use('/', create);
router.use('/', redeem);


module.exports = router;