app.factory('drivers', ['$http', '$q', 'baseServiceUrl', 'authorization', 'identity',
    function($http, $q, baseServiceUrl, authorization, identity) {
        'use strict';

        var driversApi = baseServiceUrl + '/api/Drivers',
        deferred = $q.defer();

        return {
            getDrivers: function getDrivers(options) {
                var url = driversApi;

                if (options) {
                    if (options.Page) {
                        url = url += '?Page=' + options.Page;
                    }
                    else {
                        url = url += '?Page=1';
                    }

                    if (options.Username) {
                        url = url += '&Username=' + options.Username;
                    }
                }

                if (identity.getCurrentUser()) {
                    var headers = authorization.getAuthorizationHeader();
                    $http.get(url, { headers: headers })
                        .success(function (data) {
                            deferred.resolve(data);
                        })
                        .error(function (err) {
                            deferred.reject(err);
                        });
                } else {
                    $http.get(driversApi)
                        .success(function (data) {
                            deferred.resolve(data);
                        })
                        .error(function (err) {
                            deferred.reject(err);
                        });
                }

                return deferred.promise;
            },
            getDriver: function getDriver(id) {
                var deferred = $q.defer();
                var headers = authorization.getAuthorizationHeader();

                $http.get(driversApi + '/' + id,
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
                    .error(function (err) {
                        deferred.reject(err);
                    });

                return deferred.promise;
            }
        };
    }]);
