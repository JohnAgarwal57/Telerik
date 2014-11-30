var User = require('mongoose').model('User'),
    Message = require('mongoose').model('Message');

module.exports = {
    sendMessage: function send(message) {
        var from;
        var to;
        User
            .find({userName: message.from})
            .exec(function (err, result) {
                if (err) {
                    return res.status(404).send('Cannot find the user: ' + err);
                }
                from = result[0];
                User.find({userName: message.to}).exec(function (err, result) {
                    if (err) {
                        return res.status(404).send('Cannot find the user: ' + err);
                    }
                    to = result[0];
                    Message.create({
                        from: from,
                        to: to,
                        text: message.text
                    });
                });
            });
    },
    getMessages: function get(users, callback) {
        var from;
        var to;
        User
            .findOne({userName: users.with})
            .exec(function (err, result) {
                if (err) {
                    return res.status(404).send('Cannot find the "with" user: ' + err);
                }
                from = result;
                User
                    .findOne({userName: users.and})
                    .exec(function (err, result) {
                        if (err) {
                            return res.status(404).send('Cannot find the "and" user: ' + err);
                        }
                        to = result;
                        Message
                            .find({from: from, to: to })
                            .exec(function (err, result) {
                                if (err) {
                                    return res.status(404).send('Cannot messages between the two users: ' + err);
                                }

                                callback(result);
                            });
                    });
            });
    }
};
