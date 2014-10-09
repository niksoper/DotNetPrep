(function () {

    var carTraderApp = angular.module('carTraderApp', ['ngRoute', 'carTraderControllers'])
        .config(['$routeProvider', function($routeProvider) {
            $routeProvider.when('/ads', {
                templateUrl: 'app/views/allAdverts.html',
                controller: 'allAdverts'
            })
            .when('/ads/new', {
                templateUrl: 'app/views/newAdvert.html',
                controller: 'newAdvert'
            })
            .otherwise({
                redirectTo: '/ads'
            });
        }]);

})();