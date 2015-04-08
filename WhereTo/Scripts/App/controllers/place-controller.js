;(function() {
    'use strict';
angular.module('WhereToApp')
.controller('PlaceCtrl', function ($rootScope, $scope, placeRepository, $location) {
    $(".map-jumbotron").show();

    $scope.save = function(place) {
        placeRepository.save(place);
        $location.path("/ViewDestination");    
    }
    
    //From Google Place Finder documentation: https://developers.google.com/maps/documentation/javascript/examples/places-placeid-finder
    $scope.mapstart = function initialize() {
        var mapOptions = {
            center: { lat: 36.1667, lng: -86.7833 },
            zoom: 7,
        };
        var map = new google.maps.Map(document.getElementById('map-canvas'),
          mapOptions);

        $rootScope.map = map;

        var input = (document.getElementById('pac-input'));

        var autocomplete = new google.maps.places.Autocomplete(input);
        autocomplete.bindTo('bounds', map);

        map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

        var infowindow = new google.maps.InfoWindow();
        var marker = new google.maps.Marker({
            map: map
    
        });
        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });

        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            infowindow.close();
            var place = autocomplete.getPlace();
            if (!place.geometry) {
                return;
            }

            if (place.geometry.viewport) {
                map.fitBounds(place.geometry.viewport);
            } else {
                map.setCenter(place.geometry.location);
                map.setZoom(17);
            }

            // Set the position of the marker using the place ID and location
            marker.setPlace({
                placeId: place.place_id,
                location: place.geometry.location
            });
            marker.setVisible(true);
            if (place.photos) {
                marker.icon = place.photos
            }

            infowindow.setContent('<div><strong>' + place.name + '</strong><br>' +
                place.formatted_address + '<br><button class="add-map">Add to Destination</button>');
            infowindow.open(map, marker);

            //Populate the input boxes with the name and address. Saves ID internally.
            $(".add-map").click(function () {
                $("#destination").val(place.place_id).trigger("input");
                $("#placeName").val(place.name).trigger("input");
                $("#placeAddress").val(place.formatted_address).trigger("input");
                console.log(place.place_id);    
            })

        });
        $scope.places = placeRepository.getAll();
        if ($scope.places == null) {
            $('.others-title').hide();
        }

        $scope.myplaces = placeRepository.get();
    }

    google.maps.event.addDomListener(window, 'load', $scope.mapstart);

    $scope.AddMyList = function (place) {
        place.isCompleted = false;
        placeRepository.save(place)
        $location.path("/ViewDestination");
    }
   
})

})();
