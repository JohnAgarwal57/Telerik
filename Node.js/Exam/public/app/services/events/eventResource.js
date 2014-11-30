app.factory('eventResource', ['$resource', 'identity', function ($resource, identity) {
    'use strict';

    var eventResource = $resource('/api/events', null, {
            update: {
                method: 'PUT',
                isArray: false
            },
            post: {
                method: 'POST',
                isArray: false
            }
        }),
        passedEventResource = $resource( '/api/passed-events', null, {
            get: {
                method:'GET',
                isArray:true
            }
        }),
        activeEventsResource = $resource('/api/events/:page', {page:'@page'}, {
            get: {
                method:'GET',
                isArray:true
            }
        }),
        eventDetailResource = $resource('/api/event-details/:id', {event:'@event'}, {
            get: {
                method:'GET',
                isArray:false
            }
        }),
        leaveResource = $resource('/api/leave-events', null, {
            update: {
                method: 'PUT',
                isArray: false
            }
        }),
        userEventsResource = $resource('/api/my-events/:username', {username:'@username'}, {
            get: {
                method:'GET',
                isArray:true
            }
        }),
        joinedEventsResource = $resource('/api/joined-events/:username', {username:'@username'}, {
            get: {
                method:'GET',
                isArray:true
            }
        }),
        passedResource = $resource('/api/pass-events/:username', {username:'@username'}, {
            get: {
                method:'GET',
                isArray:true
            }
        }),
        user = identity.currentUser,
        username  = identity.currentUser.username;

    return {
        add: function add(event) {
            return eventResource.post(event);
        },
        getPassed: function getPassed(){
            return passedEventResource.get();
        },
        getActive: function getActive(currentPage){
            return activeEventsResource.get({
                page: currentPage
            });
        },
        getById: function getById(id){
            return eventDetailResource.get({
                id: id
            });
        },
        join: function join(event) {
            return eventResource.update({
                event: event,
                user:user
            });
        },
        leave: function leave(event) {
            return leaveResource.update({
                event: event,
                user:user
            });
        },
        getUserEvents: function getUserEvents() {
            return userEventsResource.get({
                username: username
            });
        },
        getJoinedEvents: function getJoinedEvents() {
            return joinedEventsResource.get({
                username: username
            });
        },
        getPassedEvents: function getPassedEvents() {
            return passedResource.get({
                username: username
            });
        }
    };
}]);
