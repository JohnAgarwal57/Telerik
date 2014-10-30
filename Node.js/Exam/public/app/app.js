'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies', 'ui.bootstrap']).
    config(['$routeProvider', function($routeProvider) {
        var routeUserChecks = {
            authenticated: {
                authenticate: function(auth) {
                    return auth.isAuthenticated();
                }
            }
        };

        $routeProvider
            .when('/', {
                templateUrl: '/partials/public/home',
                controller: 'HomeCtrl'
            })
            .when('/user-register', {
                templateUrl: '/partials/user/user-register',
                controller: 'SignUpCtrl'
            })
            .when('/user-profile', {
                templateUrl: '/partials/user/user-profile',
                controller: 'ProfileCtrl',
                resolve: routeUserChecks.authenticated
            })
            .when('/create-event', {
                templateUrl: '/partials/events/create-event',
                controller: 'CreateEventCtrl',
                resolve: routeUserChecks.authenticated
            })
            .when('/event-details/:id', {
                templateUrl: '/partials/events/event-details',
                controller: 'EventCtrl',
                resolve: routeUserChecks.authenticated
            })
            .when('/active-events', {
                templateUrl: '/partials/events/active-events',
                controller: 'ListEventCtrl',
                resolve: routeUserChecks.authenticated
            })
            .when('/unauthorized', {
                templateUrl: "/partials/public/unauthorized"
            })
            .otherwise({ redirectTo: '/' });
    }])
    .value('toastr', toastr);

app.run(function($rootScope, $location) {
    $rootScope.$on('$routeChangeError', function(ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/unauthorized');
        }
    })
});
