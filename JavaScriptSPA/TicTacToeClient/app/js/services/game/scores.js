ticTacToeApp.factory('scores',
    function($http, $q, identity, authorization, baseServiceUrl) {
        'use strict';

        var gamesApi = baseServiceUrl + '/api/Scores',
            deferred = $q.defer();

        return {
            getHighScore: function getHighScore() {
                var headers = authorization.getAuthorizationHeader();

                $http.get(gamesApi,
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
        };
    });