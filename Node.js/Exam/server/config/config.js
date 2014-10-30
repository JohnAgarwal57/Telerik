var path = require('path');
var rootPath = path.normalize(__dirname + '/../../')

module.exports = {
    development: {
        rootPath: rootPath,
        db: 'mongodb://localhost/TelerikEvents',
        port: process.env.PORT || 9999
    },
    rootPath : rootPath
};
