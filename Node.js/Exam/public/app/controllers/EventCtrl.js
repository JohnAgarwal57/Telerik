app.controller('EventCtrl', ['$scope', '$routeParams', '$location', 'notifier', 'identity', 'auth', 'eventResource',
    function ($scope, $routeParams, $location, notifier, identity, auth, eventResource) {
        'use strict';

        eventResource
            .getById($routeParams.id)
            .$promise
            .then(function (data) {
                $scope.event = data;
            }, function (err) {
                notifier.error(err.data);
                $location.path('/unauthorized');
            });

        $scope.join = function (event) {
            eventResource
                .join(event)
                .$promise
                .then(function () {
                    notifier.success('You have join the event');
                }, function (err) {
                    notifier.error(err.data);
                    $location.path('/unauthorized');
                });
        };

        $scope.leave = function (event) {
            eventResource
                .leave(event)
                .$promise
                .then(function () {
                    notifier.success('You leaved the event');
                }, function (err) {
                    notifier.error(err.data);
                    $location.path('/unauthorized');
                });
        };
    }]);