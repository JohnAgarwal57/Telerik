app.controller('SignUpCtrl', ['$scope', '$location', 'auth', 'notifier',
	function($scope, $location, auth, notifier) {
		'use strict';
	
		$scope.signup = function(user) {
			auth.signup(user).then(function() {
				notifier.success('Registration successful!');
				$location.path('/');
			});
		};
	}]);