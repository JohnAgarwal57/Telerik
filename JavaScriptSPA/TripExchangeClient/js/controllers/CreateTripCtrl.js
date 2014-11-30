app.controller('CreateTripCtrl', ['$scope', '$location', 'notifier', 'identity', 'auth', 'trips', 'cities',
    function CreateTripCtrl($scope, $location, notifier, identity, auth, trips, cities) {
        'use strict';

        if (identity.getCurrentUser() === undefined) {
            notifier.error('Please login!');
            $location.path('/unauthorized');
        }

        (function getCities() {
            cities
                .getCities()
                .then(function (data) {
                    $scope.cities = data;
                }, function (err) {
                    notifier.error(err.message);
                    $location.path('/unauthorized');
                });

        })();

        $scope.clear = function () {
            $scope.trip.DepartureTime = null;
        };

        $scope.open = function($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.opened = true;
        };

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

        $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        $scope.format = $scope.formats[1];

        $scope.createTrip = function(trip) {
            if (identity.getCurrentUser() === undefined) {
                notifier.error('Please login!');
                $location.path('/');
            } else {
                trips
                    .createTrip(trip)
                    .then(function () {
                        notifier.success('Created successful!');
                        $location.path('/trips');
                    }, function (err) {
                        notifier.error(err.message);
                        $location.path('/unauthorized');
                    });
            }
        };
    }]);