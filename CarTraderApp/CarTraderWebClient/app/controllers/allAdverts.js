(function () {

    function allAdverts($scope, $http) {

        $http.get('http://localhost:51550/api/advert').then(function (response) {

            $scope.adverts = response.data;

        });

        $scope.removeAdvert = function (id) {

            $http.delete('http://localhost:51550/api/advert/' + id).then(function (response) {

                $scope.adverts = $scope.adverts.filter(function (ad) {
                    return ad.Id !== id;
                });

            });

        };

    }

    var carTraderControllers = angular
        .module('carTraderControllers')
        .controller('allAdverts', ['$scope', '$http', allAdverts]);

})();