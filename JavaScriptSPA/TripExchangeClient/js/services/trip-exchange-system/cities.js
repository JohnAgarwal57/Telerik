app.factory('cities', ['$http', '$q', 'baseServiceUrl',
    function($http, $q, baseServiceUrl) {
        'use strict';

        var citiesApi = baseServiceUrl + '/api/Cities',
            deferred = $q.defer();

        return {
            getCities: function getCities() {
                $http.get(citiesApi)
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
