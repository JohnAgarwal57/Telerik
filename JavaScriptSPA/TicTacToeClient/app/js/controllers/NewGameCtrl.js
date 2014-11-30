ticTacToeApp.controller('NewGameCtrl',
    function NewGameCtrl($scope, notifier, game, identity) {
        'use strict';

        $scope.newGame = function newGame(gameName) {
            if (!identity.isAuthenticated()) {
                notifier.error('Not logged in!');
            }
            else {
                game.createGame(gameName).then(function() {
                    notifier.success('Created');
                    $location.path('/my-games');
                });
            }
        };
    });
