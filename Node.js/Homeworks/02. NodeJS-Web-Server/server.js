var PORT = 4321,
    http = require('http'),
    fs = require('fs'),
    formidable = require('formidable'),
    url = require('url'),
    path = require('path'),
    rootPath = path.normalize(__dirname + '/server/views/'),
    uploadDir = '/upload';

var server = http.createServer(function createServer(req, res) {
    'use strict';

    if (req.url === '/') {
        fs.readFile(rootPath + 'index.html', function (err, data) {
            if (err) {
                console.log(err);
            }
            res.end(data);
        });
    }
    else if (req.url === '/upload' && req.method.toLowerCase() === 'post') {
        var form = new formidable.IncomingForm();

        form.uploadDir = '.'+ uploadDir;
        form.encoding = 'utf-8';
        form.keepExtensions = true;
        form.on('error', function (error) {
            res.writeHead(500, {'content-type': 'text/plain'});
            res.write(error.message);
            res.end();
        });

        form.parse(req, function (err, fields, files) {
            var fileName = files['file-name'].path.substr(uploadDir.length),
                downloadLink = '<a href="http://localhost:4321/upload?file=' + fileName + '" download="' + files['file-name'].name + '">Download link</a>';

            res.writeHead(200, {
                'content-type': 'text/html'
            });
            res.write(downloadLink);
            res.end();
        });
    }
    else if ((req.url.indexOf('/upload?') === 0) && (req.method.toLowerCase() === 'get')) {
        var query = url.parse(req.url, true);

        if (query.query.file) {
            var stream = fs.createReadStream('./upload/' + query.query.file);
            stream.on('error', function (error) {
                res.writeHead(404, {
                    'content-type': 'text/plain'
                });
                res.write(http.STATUS_CODES[404]);
                res.end();
            });
            res.writeHead(200);
            stream.pipe(res);
            stream.on('end', function(){
                res.end();
            });
        }
        else {
            res.writeHead(400, {
                'content-type': 'text/plain'
            });
            res.write(http.STATUS_CODES[400]);
            res.end();
        }
    }
    else {
        res.writeHead(404, {
            'content-type': 'text/plain'
        });
        res.write(http.STATUS_CODES[404]);
        res.end();
    }
}).listen(PORT);

console.log('Server is listening on port ' + PORT);