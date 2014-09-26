'use strict';

ticTacToeApp.controller('ScoresCtrl', function ScoresCtrl($scope, scores) {
    (function getHighScore() {
        scores
            .getHighScore()
            .then(function(data) {
                $scope.highScore = data;
            });
    })();
});

