angular.module('WhereToApp', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when("/ViewDestination", {
            templateUrl: "/templates/ViewDestination.html", controller: "PlaceCtrl"
        });
        $routeProvider.when("/AddDestination", {
            templateUrl: "/templates/AddDestination.html", controller: "PlaceCtrl"
        });
    })
.controller('PlaceCtrl', function ($scope, placeRepository, $location) {
    $scope.places = placeRepository.get();

    $scope.save = function(place) {
        placeRepository.save(place);
        $location.url("/ViewDestination");
    }
})