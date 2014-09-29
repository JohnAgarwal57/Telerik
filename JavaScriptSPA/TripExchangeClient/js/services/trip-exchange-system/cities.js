'use strict';

app.factory('cities', ['$http', '$q', 'baseServiceUrl',
    function($http, $q, baseServiceUrl) {
        var citiesApi = baseServiceUrl + '/api/Cities';

        return {
            getCities: function () {
                var deferred = $q.defer();

                $http.get(citiesApi)
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
