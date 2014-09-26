'use strict';

ticTacToeApp.controller('MyGamesCtrl', function MyGamesCtrl($scope, $location, game) {
    (function getMyGames() {
        game
            .getMyGames()
            .then(function(data) {
                $scope.games = data;
            });
    })();

    $scope.playGame = function (gameId) {
        $location.path('/game/' + gameId);
    };
});
