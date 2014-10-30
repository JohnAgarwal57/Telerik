var controllers = require('./controllers');

module.exports = {
    registerUser: function (user) {
        controllers.users.registerUser(user);
    },
    sendMessage: function (message) {
        controllers.messages.sendMessage(message);
    },
    getMessages: function (users, callback) {
        controllers.messages.getMessages(users, callback);
    }
};
