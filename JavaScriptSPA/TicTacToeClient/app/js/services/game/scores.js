'use strict';

ticTacToeApp.factory('scores', function($http, $q, identity, authorization, baseServiceUrl) {
    var gamesApi = baseServiceUrl + '/api/Scores';

    return {
        getHighScore: function() {
            var deferred = $q.defer();
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
    }
});