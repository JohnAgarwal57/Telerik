var User = require('mongoose').model('User');

module.exports = {
    registerUser: function (user) {
        User.create(user);
    }
};
