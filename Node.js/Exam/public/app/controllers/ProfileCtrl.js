'use strict';

app.controller('ProfileCtrl', function ProfileCtrl($scope, $route, $location, notifier, identity, auth, eventResource) {
        $scope.user = {
            firstName: identity.currentUser.firstName,
            lastName: identity.currentUser.lastName,
            phone: identity.currentUser.phone,
            image: identity.currentUser.image,
            facebook: identity.currentUser.facebook,
            twitter: identity.currentUser.twitter,
            linkedin: identity.currentUser.linkedin,
            google: identity.currentUser.google
        };

        eventResource.getUserEvents().$promise.then(function (data) {
            $scope.myEvents = data;
        }, function (err) {
            notifier.error(err.data);
        });

        eventResource.getJoinedEvents().$promise.then(function (data) {
            $scope.joinedEvents = data;
        }, function (err) {
            notifier.error(err.data);
        });

        eventResource.getPassedEvents().$promise.then(function (data) {
            $scope.passedEvents = data;
        }, function (err) {
            notifier.error(err.data);
        });

        $scope.update = function(user) {
            auth.update(user).then(function() {
                $scope.firstName = user.firstName;
                $scope.lastName = user.lastName;
                notifier.success('Update successful!');
                $location.path('/');
            });
        };
    });

