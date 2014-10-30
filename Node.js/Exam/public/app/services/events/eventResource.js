app.factory('eventResource', ['$resource', 'identity', function ($resource, identity) {
    'use strict';

    var eventResource = $resource('/api/events', null, {
        update: {method: 'PUT', isArray: false},
        post: {method: 'POST', isArray: false }
    });

    var passedEventResource = $resource( '/api/passed-events', null, {
        get: {method:'GET', isArray:true}
    });

    var activeEventsResource = $resource('/api/events/:page', {page:'@page'}, {
        get: {method:'GET', isArray:true}
    });

    var eventDetailResource = $resource('/api/event-details/:id', {event:'@event'}, {
        get: {method:'GET', isArray:false}
    });

    var leaveResource = $resource('/api/leave-events', null, {
        update: {method: 'PUT', isArray: false}
    });

    var userEventsResource = $resource('/api/my-events/:username', {username:'@username'}, {
        get: {method:'GET', isArray:true}
    });

    var joinedEventsResource = $resource('/api/joined-events/:username', {username:'@username'}, {
        get: {method:'GET', isArray:true}
    });

    var passedResource = $resource('/api/pass-events/:username', {username:'@username'}, {
        get: {method:'GET', isArray:true}
    });

    return {
        add: function (event) {
            return eventResource.post(event);
        },
        getPassed: function(){
            return passedEventResource.get();
        },
        getActive: function(currentPage){
            return activeEventsResource.get({page: currentPage});
        },
        getById: function(id){
            return eventDetailResource.get({id: id});
        },
        join: function(event) {
            var user = identity.currentUser;
            return eventResource.update({event: event, user:user});
        },
        leave: function(event) {
            var user = identity.currentUser;
            return leaveResource.update({event: event, user:user});
        },
        getUserEvents: function() {
            var username  = identity.currentUser.username;
            return userEventsResource.get({username: username});
        },
        getJoinedEvents: function() {
            var username  = identity.currentUser.username;
            return joinedEventsResource.get({username: username});
        },
        getPassedEvents: function() {
            var username  = identity.currentUser.username;
            return passedResource.get({username: username});
        }
    };
}]);
