var encryption = require('../utilities/encryption'),
    users = require('../data/usersData');

module.exports = {
    createUser: function createUser(req, res, next) {
        var newUserData = req.body;

        if(newUserData.password !== newUserData.confirmPassword) {
            return res.status(400).send('Passwords don\'t match!');
        } else if(newUserData.password.length < 6 || newUserData.password.length > 20) {
            return res.status(400).send('Password must be between 6 and 20 symbols');
        } else {
            newUserData.username = req.body.username.toLowerCase();
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);

            users.create(newUserData, function(err, user) {
                if (err) {
                    return res.status(400).send('Failed to register new user: ' + err);
                }

                res.status(201).send('Created successful');
            });
        }
    },
    updateUser: function updateUser(req, res, next) {
        if (req.user._id == req.body._id || req.user.role == 'admin') {
            var updatedUserData = req.body;

            if (updatedUserData.password && updatedUserData.password.length > 0) {
                if(updatedUserData.password !== updatedUserData.confirmPassword) {
                    return res.status(400).send('Passwords don\'t match!');
                }
                updatedUserData.salt = encryption.generateSalt();
                updatedUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
            }

            users.update({
                    _id: req.body._id
                },
                updatedUserData,
                function() {
                    res.end();
                });
        }
        else {
            return res.status(400).send('You do not have permissions!');
        }
    },
    deleteUser: function deleteUser(req, res, next) {
        if (req.user._id || req.user.role == 'admin') {
            users.remove({
                    _id: req.user._id
                }, function() {
                    res.end();
                });
        }
        else {
            return res.status(400).send('You do not have permissions!');
        }
    },
    getAllUsers: function getAllUsers(req, res) {
        users
            .all({})
            .exec(function(err, collection) {
                if (err) {
                    return res.status(400).send('Users could not be loaded: ' + err);
                }

                res.send(collection);
            });
    }
};
