;(function() {
    'use strict';
    angular.module('WhereToApp')

.controller('ViewCtrl', function ($scope, placeRepository, $location) {
    $(".map-jumbotron").hide();
    $('.random-tile').hide();
    $scope.places = placeRepository.get();
    $scope.Completed = function (place) {
        placeRepository.update(place);
    }

    $scope.Randomfunction = function () {
        if (typeof ($scope.selectedCategory) == "undefined") {
            var randomPlace = Math.floor(Math.random() * ($scope.places.length - 0));
            $scope.Random = $scope.places[randomPlace];
            console.log($scope.Random);
            $scope.path();
        }

        else if ($scope.selectedCategory.category != null) {
            var selectedPlaces = [];
            for (var i = 0; i < $scope.places.length; i++) {
                if ($scope.places[i].category == $scope.selectedCategory.category) {
                    selectedPlaces.push($scope.places[i]);
                    console.log(selectedPlaces);
                }
            }

            var randomPlace = Math.floor(Math.random() * (selectedPlaces.length - 0));
            $scope.Random = selectedPlaces[randomPlace];
            console.log($scope.Random);
            $scope.path();
        }
    };

    $scope.path = function () {
        $location.path("/" + $scope.Random.id + "/edit")
    };


    $location.path("/ViewDestination");
})
})();