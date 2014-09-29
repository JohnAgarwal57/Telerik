'use strict';

app.factory('trips', ['$http', '$q', '$location', 'identity', 'authorization', 'baseServiceUrl',
    function($http, $q, $location, identity, authorization, baseServiceUrl) {
        var tripsApi = baseServiceUrl + '/api/Trips';

        return {
            createTrip: function (trip) {
                var deferred = $q.defer();
                var headers = authorization.getAuthorizationHeader();

                $http.post(tripsApi, trip, { headers: headers })
                    .success(function (data) {
                        deferred.resolve(data);
                    })
                    .error(function (err) {
                        deferred.reject(err);
                    });

                return deferred.promise;
            },
            getTrips: function (options) {
                var deferred = $q.defer();
                var url = tripsApi;

                if (options) {
                    if (options.Page) {
                        url = url += '?Page=' + options.Page;
                    } else {
                        url = url += '?Page=1';
                    }

                    if (options.OrderBy) {
                        url = url += '&OrderBy=' + options.OrderBy;
                    }

                    if (options.OrderType) {
                        url = url += '&OrderType=' + options.OrderType;
                    }

                    if (options.From) {
                        url = url += '&From=' + options.From;
                    }

                    if (options.To) {
                        url = url += '&To=' + options.To;
                    }

                    if (options.Finished) {
                        url = url += '&Finished=' + options.Finished;
                    }

                    if (options.OnlyMine) {
                        url = url += '&OnlyMine=' + options.OnlyMine;
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
                    $http.get(tripsApi)
                        .success(function (data) {
                            deferred.resolve(data);
                        })
                        .error(function (err) {
                            deferred.reject(err);
                        });
                }

                return deferred.promise;
            },
            getTrip: function (id) {
                var deferred = $q.defer();
                var headers = authorization.getAuthorizationHeader();

                $http.get(tripsApi + '/' + id,
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
            },
            joinTrip: function (id) {
                var deferred = $q.defer();
                var headers = authorization.getAuthorizationHeader();

                $http.put(tripsApi + '/' + id, {}, { headers: headers })
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
