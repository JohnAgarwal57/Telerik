var Event = require('mongoose').model('Event');

module.exports = {
    create: function(user, callback) {
        Event.create(user, callback);
    },
    update: function(body, user, callback) {
        Event.update(body, user, callback);
    },
    remove: function(body, callback) {
        Event.remove(body, callback);
    },
    active: function() {
        var today = new Date();
        return Event.find({date : {"$gt": today}}).sort('date');
    },
    passed: function() {
        var today = new Date();
        return Event.find({date : {"$lte": today}});
    },
    find: function(id) {
        return Event.findOne();
    },
    byUser: function(username) {
        return Event.find({creatorName : username});
    },
    joined: function(username) {
        var today = new Date();
        return Event.find({$where : 'this.users.indexOf(username) != -1'});
    },
    passedByUser: function(username) {
        var today = new Date();
        return Event.find({creatorName : username}).and({date : {"$lte": today}});
    }
};
