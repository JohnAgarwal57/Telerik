var auth = require('./auth'),
    controllers = require('../controllers'),
    mongoose = require('mongoose'),
    User = mongoose.model('User');

module.exports = function(app) {
    app.get('/api/users', controllers.users.getAllUsers);
    app.post('/api/users', controllers.users.createUser);
    app.put('/api/users', auth.isAuthenticated, controllers.users.updateUser);
    app.delete('/api/users', auth.isAuthenticated, controllers.users.deleteUser);

    app.get('/api/passed-events', controllers.events.getPassedEvents);
    app.get('/api/events/:page', auth.isAuthenticated, controllers.events.getActiveEvents);
    app.get('/api/event-details/:id', auth.isAuthenticated, controllers.events.getById);
    app.post('/api/events', auth.isAuthenticated, controllers.events.createEvent);
    app.put('/api/events', auth.isAuthenticated, controllers.events.join);
    app.put('/api/leave-events', auth.isAuthenticated, controllers.events.leave);

    app.get('/api/my-events/:username', auth.isAuthenticated, controllers.events.getUserEvents);
    app.get('/api/joined-events/:username', auth.isAuthenticated, controllers.events.getJoinedEvents);
    app.get('/api/pass-events/:username', auth.isAuthenticated, controllers.events.getPassedUserEvents);

    app.get('/partials/:partialArea/:partialName', function(req, res) {
        res.render('../../public/app/views/' + req.params.partialArea + '/' + req.params.partialName)
    });

    app.post('/login', auth.login);
    app.post('/logout', auth.logout);

    app.get('*', function(req, res) {
        res.render('index');
    });
};
