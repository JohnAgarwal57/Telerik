'use strict';

app.controller('TripDetailsCtrl',
    function TripDetailsCtrl($scope, $routeParams, $location, trips, identity, notifier) {
        (function getTrip() {
            if (identity.getCurrentUser() === undefined) {
                notifier.error('Please login!');
                $location.path('/unauthorized');
            } else {
                trips
                    .getTrip($routeParams.id)
                    .then(function (data) {
                        $scope.trip = data;
                    }, function (err) {
                        notifier.error(err.message);
                        $location.path('/unauthorized');
                    });
            }
        })();

        $scope.joinTrip = function(id) {
            if (identity.getCurrentUser() === undefined) {
                notifier.error('Please login!');
                $location.path('/');
            } else {
                trips
                    .joinTrip(id)
                    .then(function (product) {
                        notifier.success('Successfuly joined the trip!');
                    }, function (err) {
                        notifier.error(err.message);
                        $location.path('/unauthorized');
                    })
            }
        };
    });
