'use strict';

app.controller('CreateEventCtrl', ['$scope', '$location', 'notifier', 'identity', 'auth', 'eventResource',
    function ($scope, $location, notifier, identity, auth, eventResource) {

        $scope.initiatives = ['Software Academy', 'Algo Academy', 'School Academy', 'Kids Academy'];
        $scope.seasons = ['Started 2010', 'Started 2011', 'Started 2012', 'Started 2013'];
        $scope.categories = ['Academy initiative', 'Free time', 'General', 'Event', 'Drinking'];

        $scope.create = function createEvent(event) {
            if ($scope.eventCreateForm.$valid) {
                $scope.event.creatorName = identity.currentUser.username;
                if(identity.currentUser.phone !== undefined) {
                    $scope.event.creatorPhone = identity.currentUser.phone;
                }

                eventResource.add(event).$promise.then(function () {
                    notifier.success("Event created");
                    $location.path('/');
                }, function (err) {
                    notifier.error(err.data);
                });
            }
        };
    }]);
