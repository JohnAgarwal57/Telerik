var mongoose = require('mongoose'),
    userSchema = mongoose.Schema({
        userName: {
            type: String,
            require: '{PATH} is required',
            unique: true
        },
        password: {
            type: String,
            require: '{PATH} is required'
        }
    }),
    User = mongoose.model('User', userSchema);

module.exports.seedInitialUsers = function () {
    User
        .find({})
        .exec(function (err, collection) {
            if (err) {
                console.log('Cannot find users: ' + err);
                return;
            }

            if (collection.length === 0) {
                User.create({userName: 'firstUser', pass: '123456'});
                User.create({userName: 'secondUser', pass: '123456'});
                console.log("Starting users created");
            }
        });
};
