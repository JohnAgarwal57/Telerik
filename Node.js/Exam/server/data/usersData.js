var User = require('mongoose').model('User');

module.exports = {
    create: function(user, callback) {
        User.create(user, callback);
    },
    update: function(body, user, callback) {
        User.update(body, user, callback);
    },
    remove: function(body, callback) {
        User.remove(body, callback);
    },
    all: function() {
        return User.find({});
    },
    find: function(id) {
        return User.findOne({_id : id});
    }
};
