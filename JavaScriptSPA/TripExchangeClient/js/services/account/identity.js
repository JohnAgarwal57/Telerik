ticTacToeApp.factory('identity', ['$cookieStore', function($cookieStore) {
    'use strict';

    var cookieStorageUserKey = 'currentApplicationUser',
        currentUser;

    return {
        getCurrentUser: function getCurrentUser() {
            var savedUser = $cookieStore.get(cookieStorageUserKey);
            if (savedUser) {
                return savedUser;
            }

            return currentUser;
        },
        setCurrentUser: function setCurrentUser(user) {
            if (user) {
                $cookieStore.put(cookieStorageUserKey, user);
            }
            else {
                $cookieStore.remove(cookieStorageUserKey);
            }

            currentUser = user;
        },
        isAuthenticated: function isAuthenticated() {
            return !!this.getCurrentUser();
        }
    };
}]);