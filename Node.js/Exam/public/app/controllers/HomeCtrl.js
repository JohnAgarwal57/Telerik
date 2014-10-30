'use strict';

app.controller('HomeCtrl',
    function HomeCtrl($scope, $routeParams, $location, identity, notifier, eventResource) {
        eventResource.getPassed().$promise.then(function (data) {
            $scope.events = data;
        }, function (err) {
            notifier.error(err.data);
        });
    });