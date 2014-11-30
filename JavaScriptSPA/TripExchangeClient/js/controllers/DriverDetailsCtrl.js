app.controller('DriverDetailsCtrl',
    function DriverDetailsCtrl($scope, $routeParams, $location, drivers, identity, notifier) {
        'use strict';

        (function getDriver() {
            if (identity.getCurrentUser() === undefined) {
                notifier.error('Please login!');
                $location.path('/unauthorized');
            } else {
                drivers
                    .getDriver($routeParams.id)
                    .then(function (data) {
                        $scope.driver = data;
                        $scope.saveTrips = $scope.driver.trips;
                    }, function (err) {
                        notifier.error(err.message);
                        $location.path('/unauthorized');
                    });
            }
        })();

        $scope.selectOnlyMine = function() {
            if (identity.getCurrentUser() === undefined) {
                notifier.error('Please login!');
                $location.path('/');
            } else {
                if ($scope.onlyMine) {
                    var result = [];
                    var allDrivers = $scope.driver.trips;

                    for (var i = 0; i < allDrivers.length; i++) {
                        if (allDrivers[i].isMine === true) {
                            result.push(allDrivers[i]);
                        }
                    }

                    $scope.driver.trips = result;
                } else
                {
                    $scope.driver.trips= $scope.saveTrips;
                }
            }
        };

        $scope.selectOnlDrivers = function() {
            if (identity.getCurrentUser() === undefined) {
                notifier.error('Please login!');
                $location.path('/');
            } else {
                if ($scope.onlyDriver) {
                    var result = [];
                    var allDrivers = $scope.driver.trips;

                    for (var i = 0; i < allDrivers.length; i++) {
                        if (allDrivers[i].driverName == $scope.driver.name) {
                            result.push(allDrivers[i]);
                        }
                    }

                    $scope.driver.trips = result;
                } else
                {
                    $scope.driver.trips= $scope.saveTrips;
                }
            }
        };
    });
