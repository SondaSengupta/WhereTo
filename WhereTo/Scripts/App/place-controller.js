angular.module('WhereToApp', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when("/ViewDestination", {
            templateUrl: "/templates/ViewDestination.html", controller: "PlaceCtrl"
        });
        $routeProvider.when("/AddDestination", {
            templateUrl: "/templates/AddDestination.html", controller: "PlaceCtrl"
        });
    })
    //.config(function (uiGmapGoogleMapApiProvider) {
    //    console.log("Onward to Google!");
    //    uiGmapGoogleMapApiProvider.configure({
    //        key: 'AIzaSyDzuf3PKADN4hVI4ry8q0bVMsgFMPq_ofk',
    //        v: '3.17',
    //        libraries: 'weather, places'
    //    });
    //})
.controller('PlaceCtrl', function ($scope, placeRepository, $location) {
    $scope.places = placeRepository.get();

    $scope.save = function(place) {
        placeRepository.save(place);
        $location.url("/ViewDestination");
    }

    
    
})