'use strict';

app.factory('stats', ['$http', '$q', 'baseServiceUrl',
    function($http, $q, baseServiceUrl) {
        var statsApi = baseServiceUrl + '/api/Stats';

        return {
            getStats: function () {
                var deferred = $q.defer();

                $http.get(statsApi)
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (err) {
                        deferred.reject(err);
                    });

                return deferred.promise;
            }
        }
    }]);
