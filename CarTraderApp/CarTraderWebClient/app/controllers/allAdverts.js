(function () {

    function allAdverts($scope, $http) {

        $http.get('http://localhost:51550/api/advert').then(function (response) {

            $scope.adverts = response.data;

        });

    }

    var carTraderControllers = angular
        .module('carTraderControllers')
        .controller('allAdverts', ['$scope', '$http', allAdverts]);

})();