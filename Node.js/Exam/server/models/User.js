var mongoose = require('mongoose'),
    encryption = require('../utilities/encryption'),
    userSchema = mongoose.Schema({
        username: {
            type: String,
            require: '{PATH} is required',
            unique: true
        },
        firstName: {
            type: String,
            require: '{PATH} is required'
        },
        lastName: {
            type: String,
            require: '{PATH} is required'
        },
        email: {
            type: String,
            require: '{PATH} is required'
        },
        phone: String,
        points: {
            type: Number,
            default: 0
        },
        initiative: {
            type: String,
            require: '{PATH} is required'
        },
        season: {
            type: String,
            require: '{PATH} is required'
        },
        image: {
            type: String,
            default: ''
        },
        facebook: String,
        twitter: String,
        linkedin: String,
        google: String,
        salt: String,
        hashPass: String
    }),
    User = mongoose.model('User', userSchema);

userSchema.method({
    authenticate: function authenticate(password) {
        if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
            return true;
        } else {
            return false;
        }
    }
});

module.exports.seedInitialUsers = function seedInitialUsers() {
    User
        .find({})
        .exec(function(err, collection) {
            if (err) {
                console.log('Cannot find users: ' + err);
                return;
            }

            if (collection.length === 0) {
                var salt;
                var hashedPwd;

                salt = encryption.generateSalt();
                hashedPwd = encryption.generateHashedPassword(salt, '123456');
                User.create({
                    username: 'pesho',
                    firstName: 'Pesho',
                    lastName: 'Peshov',
                    email: 'pesho@abv.bg',
                    initiative:'Software Academy',
                    season: ['Started 2010', 'Started 2011', 'Started 2012', 'Started 2013'],
                    salt: salt,
                    hashPass: hashedPwd
                });

                salt = encryption.generateSalt();
                hashedPwd = encryption.generateHashedPassword(salt, '123456');
                User.create({
                    username: 'gosho',
                    firstName: 'Gosho',
                    lastName: 'Goshov',
                    email: 'gosho@abv.bg',
                    initiative:'Software Academy',
                    season: 'Started 2010',
                    salt: salt,
                    hashPass: hashedPwd
                });

                console.log("Starting users created");
            }
        });
};
