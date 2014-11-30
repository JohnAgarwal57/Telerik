var ticTacToeApp = angular.module('ticTacToeApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/partials/home.html'
            })
            .when('/new-game', {
                templateUrl: 'views/partials/new-game.html',
                controller: 'NewGameCtrl'
            })
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/join-game', {
                templateUrl: 'views/partials/join-game.html',
                controller: 'AvailableGamesCtrl'
            })
            .when('/my-games', {
                templateUrl: 'views/partials/my-games.html',
                controller: 'MyGamesCtrl'
            })
            .when('/game/:id', {
                templateUrl: 'views/partials/game-table.html',
                controller: 'GameStatusCtrl'
            })
            .when('/high-scores', {
                templateUrl: 'views/partials/high-scores.html',
                controller: 'ScoresCtrl'
            })
            .when('/about', {
                templateUrl: 'views/partials/about.html'
            })
            .otherwise({redirectTo: '/'});
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:33257');