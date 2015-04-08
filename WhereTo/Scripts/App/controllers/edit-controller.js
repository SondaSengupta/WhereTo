;(function() {
    'use strict';
    angular.module('WhereToApp')
.controller('EditCtrl', function ($location, $routeParams, placeRepository, $scope) {
    $(".map-jumbotron").hide();
    var id = $routeParams.id;

    $scope.updateDetails = function (Detail) {
        placeRepository.updateDetails(Detail);
        $location.path("/ViewDestination")
    }


})
})();