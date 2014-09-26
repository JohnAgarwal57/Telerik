'use strict';

ticTacToeApp.factory('game', function($http, $q, identity, authorization, baseServiceUrl) {
    var gamesApi = baseServiceUrl + '/api/Games',
        newGameRoute = '/Create',
        availableGamesRoute = '/GetAvailableGames',
        myGamesRoute = '/GetMyGames';


    return {
        createGame: function (name) {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();

            $http.post(gamesApi + newGameRoute, {GameName: name}, { headers: headers })
                .success(function() {
                    deferred.resolve();
                });

            return deferred.promise;
        },
        getAvailableGames: function() {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();

            $http.get(gamesApi + availableGamesRoute,
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        getMyGames: function() {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();

            $http.get(gamesApi + myGamesRoute,
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        joinGame: function (gameId) {
            var deferred = $q.defer();

            $http.post(gamesApi + '/Join', {
                    GameId: gameId
                },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        getGameStatus: function (gameId) {
            var deferred = $q.defer();

            $http.post(gamesApi + '/Status', {
                    GameId: gameId
                },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        },
        playGame: function (gameId, row, col) {
            var deferred = $q.defer();

            $http.post(gamesApi + '/Play', {
                    GameId: gameId,
                    Row: row,
                    Col: col
                },
                {
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj)
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        return str.join("&");
                    },
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
                    }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (data) {
                    deferred.reject(data);
                });

            return deferred.promise;
        }
    }
});