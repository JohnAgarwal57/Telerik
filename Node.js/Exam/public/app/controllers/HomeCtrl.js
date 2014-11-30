app.controller('HomeCtrl',
	function HomeCtrl($scope, $routeParams, $location, identity, notifier, eventResource) {
		'use strict';

		eventResource.getPassed()
			.$promise
			.then(function (data) {
				$scope.events = data;
			}, function (err) {
				notifier.error(err.data);
			});
	});