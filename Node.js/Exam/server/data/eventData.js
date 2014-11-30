var Event = require('mongoose').model('Event'),
    today = new Date();

module.exports = {
    create: function create(user, callback) {
        Event.create(user, callback);
    },
    update: function update(body, user, callback) {
        Event.update(body, user, callback);
    },
    remove: function remove(body, callback) {
        Event.remove(body, callback);
    },
    active: function active() {
        return Event.find({date : {"$gt": today}}).sort('date');
    },
    passed: function passed() {
        return Event.find({date : {"$lte": today}});
    },
    find: function find(id) {
        return Event.findOne();
    },
    byUser: function byUser(username) {
        return Event.find({creatorName : username});
    },
    joined: function joined(username) {
        return Event.find({$where : 'this.users.indexOf(username) != -1'});
    },
    passedByUser: function passedByUser(username) {
        return Event.find({creatorName : username}).and({date : {"$lte": today}});
    }
};
