ticTacToeApp.factory('auth', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl',
    function($http, $q, identity, authorization, baseServiceUrl) {
        'use strict';

        var usersApi = baseServiceUrl + '/api/users',
            deferred = $q.defer();

        return {
            signup: function signup(user) {
                $http.post(usersApi + '/register', user)
                    .success(function() {
                        deferred.resolve();
                    }, function(response) {
                        deferred.reject(response);
                    });

                return deferred.promise;
            },
            login: function login(user){
                user['grant_type'] = 'password';
                $http.post(usersApi + '/login', 'username=' + user.username + '&password=' + user.password + '&grant_type=password', { headers: {'Content-Type': 'application/x-www-form-urlencoded'} })
                    .success(function(response) {
                        if (response["access_token"]) {
                            identity.setCurrentUser(response);
                            deferred.resolve(true);
                        }
                        else {
                            deferred.resolve(false);
                        }
                    });

                return deferred.promise;
            },
            logout: function logout() {
                var headers = authorization.getAuthorizationHeader();
                $http.post(usersApi + '/logout', {}, { headers: headers })
                    .success(function() {
                        identity.setCurrentUser(undefined);
                        deferred.resolve();
                    });

                return deferred.promise;
            },
            isAuthenticated: function isAuthenticated() {
                if (identity.isAuthenticated()) {
                    return true;
                }
                else {
                    return $q.reject('not authorized');
                }
            }
        };
    }]);