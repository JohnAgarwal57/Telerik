ticTacToeApp.factory('authorization', ['identity', function(identity) {
	'use strict';

    return {
        getAuthorizationHeader: function getAuthorizationHeader() {
            return {
                'Authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
            };
        }
    };
}]);