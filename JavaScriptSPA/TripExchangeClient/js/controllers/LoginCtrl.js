app.controller('LoginCtrl', ['$scope', '$location', 'notifier', 'identity', 'auth',
    function($scope, $location, notifier, identity, auth) {
        'use strict';
        $scope.identity = identity;

        $scope.login = function(user, loginForm) {
            if (loginForm.$valid) {
                auth.login(user).then(function(result) {
                    $location.path('/');
                    notifier.success('Successful login!');
                }, function(error) {
                    notifier.error('Username/Password combination is not valid!');
                });
            }
            else {
                notifier.error('Username and password are required fields!');
            }
        };

        $scope.logout = function() {
            auth.logout().then(function() {
                notifier.success('Successful logout!');
                if ($scope.user) {
                    $scope.user.email = '';
                    $scope.user.username = '';
                    $scope.user.password = '';
                }

                $scope.loginForm.$setPristine();
                $location.path('/');
            }, function(err) {
                notifier.error(err.message);
            });
        };
    }]);