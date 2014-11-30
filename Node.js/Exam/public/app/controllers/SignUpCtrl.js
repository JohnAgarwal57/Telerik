app.controller('SignUpCtrl', ['$scope', '$location', 'auth', 'notifier',
    function($scope, $location, auth, notifier) {
        $scope.user = {};

        $scope.signup = function(user) {
            if(user.season !== undefined && user.initiative !== undefined) {
                if(user.password !== user.confirmPassword) {
                    notifier.error('Passwords don\'t match');
                } else if(user.password.length < 6 || user.password.length > 20) {
                    notifier.error('Password must be between 6 and 20 symbols');
                } else {
                    auth.signup(user).then(function() {
                        notifier.success('Registration successful!');
                        $location.path('/');
                    }, function(err) {
                        notifier.error(err.data);
                    });
                }
            } else {
                notifier.error('Please choose initiatives and seasons!');
            }

        };

        $scope.initiatives = ['Software Academy', 'Algo Academy', 'School Academy', 'Kids Academy'];
        $scope.seasons = ['Started 2010', 'Started 2011', 'Started 2012', 'Started 2013'];

        $scope.chooseInitiative = function() {
            var $newVal = $('#initiative').val() + $scope.choosedInitiative + ', ' ;
            $('#initiative').val($newVal);
            $scope.user.initiative = $newVal;
        };

        $scope.chooseSeason = function() {
            var $newVal = $('#season').val() + $scope.choosedSeason + ', ' ;
            $('#season').val($newVal);
            $scope.user.season = $newVal;
        };
    }]);