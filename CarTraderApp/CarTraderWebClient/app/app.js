(function () {

    var carTraderApp = angular.module('carTraderApp', ['ngRoute', 'carTraderControllers'])
        .config(['$routeProvider', function($routeProvider) {
            $routeProvider.when('/ads', {
                templateUrl: 'app/views/allAdverts.html',
                controller: 'allAdverts'
            })
            .otherwise({
                redirectTo: '/ads'
            });
        }]);

})();