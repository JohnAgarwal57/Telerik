app.factory('stats', ['$http', '$q', 'baseServiceUrl',
    function($http, $q, baseServiceUrl) {
        'use strict';

        var statsApi = baseServiceUrl + '/api/Stats',
            deferred = $q.defer();

        return {
            getStats: function getStats() {
                $http.get(statsApi)
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (err) {
                        deferred.reject(err);
                    });

                return deferred.promise;
            }
        };
    }]);
