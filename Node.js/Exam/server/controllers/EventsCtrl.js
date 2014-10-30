var encryption = require('../utilities/encryption');
var events = require('../data/eventData');
var users = require('../data/usersData');

module.exports = {
    createEvent: function(req, res, next) {
        var newEventData = req.body;

        if(newEventData.title === undefined || newEventData.title === "") {
            return res.status(400).send('Title is required');
        } else if(newEventData.description === undefined || newEventData.description === "") {
            return res.status(400).send('Description is required');
        } else if(newEventData.category === undefined || newEventData.category === "") {
            return res.status(400).send('Category is required');
        } else if(newEventData.initiative === undefined || newEventData.initiative === "") {
            return res.status(400).send('Initiative is required');
        } else if(newEventData.season === undefined || newEventData.season === "") {
            return res.status(400).send('Season is required');
        } else {
            events.create(newEventData, function(err, user) {
                if (err) {
                    return res.status(400).send('Failed to create new event: ' + err);
                }

                res.status(201).send('Created successful');
            });
        }
    },
    getActiveEvents: function(req, res) {
        var page = req.params.page;
        events.active().skip(page*10).limit(10).exec(function(err, collection) {
            if (err) {
                return res.status(400).send('Events could not be loaded: ' + err);
            }

            res.send(collection);
        })
    },
    getPassedEvents: function(req, res) {
        events.passed().exec(function(err, collection) {
            if (err) {
                return res.status(400).send('Events could not be loaded: ' + err);
            }

            res.send(collection);
        })
    },
    getById: function(req, res) {
        var id = req.params.id;
        events.find(id).exec(function(err, result) {
            if (err) {
                return res.status(400).send('Event could not be loaded: ' + err);
            }

            res.send(result);
        })
    },
    join: function(req, res) {
        var eventId = req.body.event._id;
        var userId = req.body.user._id;


        events.find(eventId).exec(function(err, event) {
            if (err) {
                return res.status(400).send("Couldn't join the event");
            }

            users.find(userId).exec(function(err, user) {
                if(user.username === req.body.event.creatorName) {
                    return res.status(400).send("Can't join you own event!");
                } else if(event.users.indexOf(userId) > -1) {
                    return res.status(400).send("You are already part of this event!");
                } else if(!(user.initiative.indexOf(event.initiative) > -1)){
                    return res.status(400).send("You cannot join this event - wrong initiative!");
                } else if(!(user.season.indexOf(event.season) > -1)){
                    return res.status(400).send("You cannot join this event - wrong season!");
                } else {
                    event.users.push(user);

                    event.save(function (err) {
                        if (err) {
                            return res.status(400).send("Couldn't join the event");
                        }
                        res.send(event);
                    });
                }
            });
        })
    },
    leave: function(req, res) {
        var eventId = req.body.event._id;
        var userId = req.body.user._id;

        events.find(eventId).exec(function(err, event) {
            if (err) {
                return res.status(400).send("Couldn't join the event");
            }

            users.find(userId).exec(function(err, user) {

                if(user.username === req.body.event.creatorName) {
                    return res.status(400).send("You can't leave your event!!");
                } else {
                    var index = event.users.indexOf(user._id);

                    if (index > -1) {
                        event.users.splice(index, 1);

                        event.save(function (err) {
                            if (err) {
                                return res.status(400).send("Couldn't join the event");
                            }
                            res.send(event);
                        });
                    } else {
                        return res.status(400).send("You are not part of this event");
                    }
                }
            });
        })
    },
    getUserEvents: function(req, res) {
        var username = req.params.username;
        events.byUser(username).exec(function(err, collection) {
            if (err) {
                return res.status(400).send('Events could not be loaded: ' + err);
            }

            res.send(collection);
        })
    },
    getJoinedEvents: function(req, res) {
        var username = req.params.username;
        events.joined(username).exec(function(err, collection) {
            if (err) {
                return res.status(400).send('Events could not be loaded: ' + err);
            }

            res.send(collection);
        })
    },
    getPassedUserEvents: function(req, res) {
        var username = req.params.username;
        events.passedByUser(username).exec(function(err, collection) {
            if (err) {
                return res.status(400).send('Events could not be loaded: ' + err);
            }

            res.send(collection);
        })
    }
};
