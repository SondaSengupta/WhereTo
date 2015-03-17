/// <reference path="Views/ViewDestination.html" />
/// <reference path="Views/AddDestination.html" />
angular.module('WhereToApp', ['ngRoute'])
    .config(function ($routeProvider) {
        $routeProvider.when("/ViewDestination", {
            templateUrl: "/templates/ViewDestination.html", controller: "PlaceCtrl"
        });
        $routeProvider.when("/AddDestination", {
            templateUrl: "/templates/AddDestination.html", controller: "PlaceCtrl"
        });
    })
.controller('PlaceCtrl', function ($scope, $http) {
})