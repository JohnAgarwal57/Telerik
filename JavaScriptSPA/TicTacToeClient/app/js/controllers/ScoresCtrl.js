ticTacToeApp.controller('ScoresCtrl',
	function ScoresCtrl($scope, scores) {
		'use strict';
		
		(function getHighScore() {
			scores
				.getHighScore()
				.then(function(data) {
					$scope.highScore = data;
				});
		})();
	});