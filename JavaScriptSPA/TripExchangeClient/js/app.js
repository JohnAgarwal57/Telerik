'use strict';

var app = angular.module('app', ['ngRoute', 'ngResource', 'ngCookies', 'ui.bootstrap']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html',
                controller: 'HomeCtrl'
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/create-trip', {
                templateUrl: 'views/partials/create-trip.html',
                controller: 'CreateTripCtrl'
            })
            .when('/view-drivers', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'ViewDriversCtrl'
            })
            .when('/view-drivers', {
                templateUrl: 'views/partials/drivers.html',
                controller: 'ViewDriversCtrl'
            })
            .when('/driver-details/:id', {
                templateUrl: 'views/partials/driver-details.html',
                controller: 'DriverDetailsCtrl'
            })
            .when('/trips', {
                templateUrl: 'views/partials/view-trips.html',
                controller: 'ViewTripsCtrl'
            })
            .when('/trip-details/:id', {
                templateUrl: 'views/partials/trip-details.html',
                controller: 'TripDetailsCtrl'
            })
            .when('/unauthorized', {
                templateUrl: 'views/partials/unauthorize.html'
            })
            .otherwise({redirectTo: '/'});
    }])
    .value('toastr', toastr)
    //.constant('baseServiceUrl', 'http://localhost:1337');
    .constant('baseServiceUrl', 'http://spa2014.bgcoder.com/');
