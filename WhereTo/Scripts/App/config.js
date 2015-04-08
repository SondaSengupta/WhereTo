;(function() {
    'use strict';
    angular.module('WhereToApp')

.config(function ($routeProvider) {
    $routeProvider.when("/ViewDestination", {
        templateUrl: "/templates/ViewDestination.html", controller: "ViewCtrl"
    });
    $routeProvider.when("/AddDestination", {
        templateUrl: "/templates/AddDestination.html", controller: "PlaceCtrl"
    });
    $routeProvider.when("/:id/edit", {
        templateUrl: "/templates/EditDestination.html", controller: "EditCtrl"

    })
})
})();