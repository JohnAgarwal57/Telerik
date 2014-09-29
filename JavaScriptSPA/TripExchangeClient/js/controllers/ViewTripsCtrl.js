'use strict';

app.controller('ViewTripsCtrl', ['$rootScope', '$scope', '$location', 'trips', 'notifier', 'identity', 'cities',
    function ViewTripsCtrl($rootScope, $scope, $location, trips, notifier, identity, cities) {
        (function getTrips() {
            trips
                .getTrips()
                .then(function (data) {
                    if (identity.getCurrentUser() === undefined) {
                        $scope.login = false;
                    } else {
                        $scope.login = true;
                    }

                    $scope.trips = data;
                    $scope.currentPage = 1;
                    $scope.totalItems = 100;

                    $scope.$watch('currentPage + numPerPage', function() {
                        var options = {
                            Page : $scope.currentPage
                        };

                        trips
                            .getTrips(options)
                            .then(function (data) {
                                if (identity.getCurrentUser() === undefined) {
                                    $scope.login = false;
                                } else {
                                    $scope.login = true;
                                }

                                $scope.trips = data;
                            }, function (err) {
                                notifier.error(err.message);
                                $location.path('/unauthorized');
                            });
                    });
                }, function (err) {
                    notifier.error(err.message);
                    $location.path('/unauthorized');
                });
        })();

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

        $scope.search = function() {
            if (identity.getCurrentUser() === undefined) {
                notifier.error('Please login!');
                $location.path('/');
            } else {
                var options = {
                    OrderBy : $scope.orderBy,
                    OrderType: $scope.orderType,
                    To:  $scope.to,
                    From : $scope.from,
                    Finished : $scope.finished,
                    OnlyMine: $scope.onlyMine,
                    Page : 1
                };
                trips
                    .getTrips(options)
                    .then(function (data) {
                        $scope.trips = data;
                    }, function (err) {
                        notifier.error(err.message);
                        $location.path('/unauthorized');
                    })
            }
        }
    }]);