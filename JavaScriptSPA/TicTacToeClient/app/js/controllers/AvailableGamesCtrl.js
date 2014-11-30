ticTacToeApp.controller('AvailableGamesCtrl',
    function AvailableGamesCtrl($scope, $location, game) {
        'use strict';

        (function getGames() {
            game
                .getAvailableGames()
                .then(function(data) {
                    $scope.games = data;
                });
        })();

        $scope.joinGame = function (gameId) {
            game
                .joinGame(gameId)
                .then(function () {
                    $location.path('/game/' + gameId);
                });
        };
    });
