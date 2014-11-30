var mongoose = require('mongoose'),
    Schema = mongoose.Schema,
    eventSchema = mongoose.Schema({
        title: {
            type: String,
            require: '{PATH} is required'
        },
        description: {
            type: String,
            require: '{PATH} is required'
        },
        latitude: Number,
        longitude: Number,
        date: Date,
        category: {
            type: String,
            require: '{PATH} is required'
        },
        initiative : {
            type: String,
            require: '{PATH} is required'
        },
        season: {
            type: String,
            require: '{PATH} is required'
        },
        creatorName: {
            type: String,
            require: '{PATH} is required' },
        creatorPhone: String,
        comments : [{
            type: Schema.ObjectId,
            ref: 'Comment'
        }],
        users : [{
            type: Schema.ObjectId,
            ref: 'User'
        }],
        organizationPoints : Number,
        venuePoints: Number
    }),
    Event = mongoose.model('Event', eventSchema);

module.exports.seedInitialEvents = function() {
    Event
        .find({})
        .exec(function(err, collection) {
            if (err) {
                console.log('Cannot find events: ' + err);
                return;
            }

            if (collection.length === 0) {
                Event.create({
                    title: 'Test',
                    description: 'Testing',
                    category: 'Free time',
                    initiative: 'Software Academy',
                    season: 'Started 2010',
                    creatorName: 'Pesho',
                    organizationPoints: '10',
                    venuePoints: '5',
                    date: new Date(2014, 5, 3, 12, 30, 30, 0)
                });
                Event.create({
                    title: 'Test1',
                    description: 'Testing',
                    category: 'Free time',
                    initiative: 'Software Academy',
                    season: 'Started 2011',
                    creatorName: 'Pesho',
                    organizationPoints: '6',
                    venuePoints: '7',
                    date: new Date(2014, 6, 3, 12, 30, 30, 0)
                });
                Event.create({
                    title: 'Test2',
                    description: 'Testing',
                    category: 'Free time',
                    initiative: 'Software Academy',
                    season: 'Started 2012',
                    creatorName: 'Pesho',
                    organizationPoints: '8',
                    venuePoints: '7',
                    date: new Date(2014, 7, 3, 12, 30, 30, 0)
                });
                console.log("Starting events created");
            }
        });
};
