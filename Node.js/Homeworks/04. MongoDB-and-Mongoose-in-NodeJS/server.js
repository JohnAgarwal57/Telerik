var express = require('express');
var app = express();

var config = require('./server/config/config');
require('./server/config/mongoose')(config);

app.listen(config.port);
console.log("Server running on port " + config.port);
