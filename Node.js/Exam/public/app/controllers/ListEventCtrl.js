'use strict';

app.controller('ListEventCtrl', ['$scope', '$location', 'notifier', 'identity', 'auth', 'eventResource',
    function ($scope, $location, notifier, identity, auth, eventResource) {
        $scope.currentPage = 0;

        $scope.previous = function() {
            if($scope.currentPage > 0) {
                $scope.currentPage--;
                eventResource.getActive($scope.currentPage).$promise.then(function (data) {
                    $scope.events = data;
                }, function (err) {
                    notifier.error(err.data);
                });
            }
        };

        $scope.next = function() {
            $scope.currentPage++;
            eventResource.getActive($scope.currentPage).$promise.then(function (data) {
                $scope.events = data;
            }, function (err) {
                notifier.error(err.data);
            });
        };

        eventResource.getActive($scope.currentPage).$promise.then(function (data) {
            $scope.events = data;
        }, function (err) {
            notifier.error(err.data);
        });
    }]);
