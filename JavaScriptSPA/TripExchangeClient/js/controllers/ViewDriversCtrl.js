app.controller('ViewDriversCtrl', ['$rootScope', '$scope', '$location', 'drivers', 'notifier', 'identity',
    function ViewDriversCtrl($rootScope, $scope, $location, drivers, notifier, identity) {
        'use strict';

        (function getDrivers() {
            drivers
                .getDrivers()
                .then(function (data) {
                    if (identity.getCurrentUser() === undefined) {
                        $scope.login = false;
                    } else {
                        $scope.login = true;
                    }

                    $scope.drivers = data;
                    $scope.currentPage = 1;
                    $scope.totalItems = 100;

                    $scope.$watch('currentPage + numPerPage', function() {
                        var options = {
                            Username : $scope.username,
                            Page : $scope.currentPage
                        };

                        drivers
                            .getDrivers(options)
                            .then(function (data) {
                                if (identity.getCurrentUser() === undefined) {
                                    $scope.login = false;
                                } else {
                                    $scope.login = true;
                                }

                                $scope.drivers = data;
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

        $scope.searchByUserName = function() {
            if (identity.getCurrentUser() === undefined) {
                notifier.error('Please login!');
                $location.path('/');
            } else {
                var options = {
                    Username : $scope.username,
                    Page : 1
                };
                drivers
                    .getDrivers(options)
                    .then(function (data) {
                        $scope.drivers = data;
                    }, function (err) {
                        notifier.error(err.message);
                        $location.path('/unauthorized');
                    });
            }
        };
    }]);
