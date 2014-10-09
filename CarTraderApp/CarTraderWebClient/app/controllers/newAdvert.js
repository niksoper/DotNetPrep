(function () {

    function newAdvert($scope, $http, $location) {

        $scope.createAd = function (ad) {

            console.log(ad);

            $http.post('http://localhost:51550/api/advert', ad).then(function () {
                $location.path('/ads');
            });
        };

    }

    var carTraderControllers = angular
        .module('carTraderControllers')
        .controller('newAdvert', ['$scope', '$http', '$location', newAdvert]);

})();