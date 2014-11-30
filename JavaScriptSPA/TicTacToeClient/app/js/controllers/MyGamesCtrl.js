ticTacToeApp.controller('MyGamesCtrl',
    function MyGamesCtrl($scope, $location, game) {
        'use strict';
        
        (function getMyGames() {
            game
                .getMyGames()
                .then(function(data) {
                    $scope.games = data;
                });
        })();

        $scope.playGame = function playGame(gameId) {
            $location.path('/game/' + gameId);
        };
    });
