'use strict';

ticTacToeApp.controller('GameStatusCtrl',
    function GameStatusCtrl($rootScope, $scope, $location, $routeParams, game, auth, identity, notifier) {

        var token = identity.getCurrentUser()['access_token']

        if (!auth.isAuthenticated()) {
            $location.path('/login');
            return;
        }

        if (!$routeParams.id) {
            $location.path('/');
            return;
        }

        getGameStatus();
        var timer = setInterval(getGameStatus, 2000);

        function getGameStatus() {
            if ($location.path().indexOf('/game/') === -1) {
                clearInterval(timer);
                return;
            }

            game
                .getGameStatus($routeParams.id, token)
                .then(function (data) {
                    if ($scope.board != data.Board) {
                        $scope.gameId = data.Id;
                        $scope.board = data.Board;
                        $scope.gameStatus = data.State;
                        $scope.cursorClass = 'allowed';

                        $scope.hasTwoPlayers = data.FirstPlayerName && data.SecondPlayerName;
                        if ($scope.hasTwoPlayers) {
                            $scope.currentPlayer = identity.getCurrentUser()['userName'];
                            $scope.firstPlayer = data.FirstPlayerName;
                            $scope.secondPlayer = data.SecondPlayerName;
                        }

                        if ($scope.gameStatus == 'WonByX') {
                            if ($scope.currentPlayer == $scope.firstPlayer) {
                                notifier.success('You won!');
                            } else {
                                notifier.error('You lost!');
                            }
                        }

                        if ($scope.gameStatus == 'WonByY') {
                            if ($scope.currentPlayer == $scope.firstPlayer) {
                                notifier.success('You lost!');
                            } else {
                                notifier.error('You won!');
                            }
                        }

                        if ($scope.gameStatus == 'Draw') {
                            notifier.success('Draw!');
                        }

                        if (data.FirstPlayerName === $rootScope.username && data.State == 2 ||
                            data.FirstPlayerName !== $rootScope.username && data.State == 1) {
                            $scope.cursorClass = 'notAllowed';
                        }

                        if ([0, 3, 4, 5].indexOf(data.State) !== -1) {
                            clearInterval(timer);
                            $scope.cursorClass = 'notAllowed';
                            return;
                        }
                    }
                }, function () {
                    clearInterval(timer);
                    $location.path('/');
                    return;
                });
        }


        $scope.click = function (row, col) {
            if ($scope.board[row * 3 + col] === '-' && [0, 3, 4, 5].indexOf($scope.gameStatus) === -1) {
                game.playGame($scope.gameId, row + 1, col + 1, token)
                    .then(function () {
                        getGameStatus();
                    }, function (e) {
                        notifier.error(e.Message);
                    });
            }
        }
    }
);
