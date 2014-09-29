'use strict';

app.controller('HomeCtrl',
    function HomeCtrl($scope, $routeParams, $location, drivers, identity, notifier, stats, trips) {
        (function getStats() {
            stats
                .getStats()
                .then(function (data) {
                    $scope.stats = data;
                }, function (err) {
                    notifier.error(err.message);
                    $location.path('/unauthorized');
                });

        })();

        (function getTrips() {
            trips
                .getTrips()
                .then(function (data) {
                    $scope.trips = data;
                }, function (err) {
                    notifier.error(err.message);
                    $location.path('/unauthorized');
                });
        })();

        (function getDrivers() {
            drivers
                .getDrivers()
                .then(function (data) {
                    $scope.drivers = data;
                }, function (err) {
                    notifier.error(err.message);
                    $location.path('/unauthorized');
                });
        })();
    });
