var User = require('mongoose').model('User');

module.exports = {
    create: function create(user, callback) {
        User.create(user, callback);
    },
    update: function update(body, user, callback) {
        User.update(body, user, callback);
    },
    remove: function remove(body, callback) {
        User.remove(body, callback);
    },
    all: function all() {
        return User.find({});
    },
    find: function find(id) {
        return User.findOne({_id : id});
    }
};
