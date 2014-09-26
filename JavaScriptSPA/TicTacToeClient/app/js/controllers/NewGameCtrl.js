'use strict';

ticTacToeApp.controller('NewGameCtrl', function NewGameCtrl($scope, notifier, game, identity) {
    $scope.newGame = function(gameName) {
        if (!identity.isAuthenticated()) {
            notifier.error('Not logged in!');
        }
        else {
            game.createGame(gameName).then(function() {
                notifier.success('Created');
                $location.path('/my-games');
            })
        }
    }
});
