angular.module('WhereToApp', ['ngRoute', 'ngResource'])
    .config(function ($routeProvider) {
        $routeProvider.when("/ViewDestination", {
            templateUrl: "/templates/ViewDestination.html", controller: "PlaceCtrl"
        });
        $routeProvider.when("/AddDestination", {
            templateUrl: "/templates/AddDestination.html", controller: "PlaceCtrl"
        });
        $routeProvider.when("/:id/edit", {
            templateUrl: "/templates/EditDestination.html", controller: "EditCtrl"
           
        })
    })
.controller('EditCtrl', function ($scope, $location, $routeParams, $http) {
    var vm = this;
    var id = $routeParams.id;
    var url = "https://maps.googleapis.com/maps/api/place/details/json?placeid=" + id + "&key=AIzaSyDzuf3PKADN4hVI4ry8q0bVMsgFMPq_ofk";
    $http.jsonp(url + '&callback=JSON_CALLBACK')
    .then(function (response) {
        console.log(response)
    });

    

})

.controller('PlaceCtrl', function ($scope, placeRepository, $location) {
    $scope.places = placeRepository.get();

    $scope.save = function(place) {
        placeRepository.save(place);
        $location.url("/ViewDestination");
    }
    
    $scope.mapstart = function initialize() {
        var mapOptions = {
            center: { lat: -33.8688, lng: 151.2195 },
            zoom: 13
        };
        var map = new google.maps.Map(document.getElementById('map-canvas'),
          mapOptions);

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

            infowindow.setContent('<div><strong>' + place.name + '</strong><br>' +
                'Place ID: ' + place.place_id + '<br>' +
                place.formatted_address + '<br><button class="add-map">Add to Destination</button>');
            infowindow.open(map, marker);

            $(".add-map").click(function () {
                $("#destination").val(place.place_id).trigger("input");
                console.log(place.place_id);    
            })

        });
    }

    google.maps.event.addDomListener(window, 'load', $scope.mapstart);
})
