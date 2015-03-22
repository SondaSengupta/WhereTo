angular.module('WhereToApp', ['ngRoute', 'ngResource', 'uiGmapgoogle-maps'])
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

        var mapOptions = {
            zoom: 4,
            center: new google.maps.LatLng(40.0000, -98.0000),
            mapTypeId: google.maps.MapTypeId.TERRAIN
        }

        $scope.map = new google.maps.Map(document.getElementById('map'), mapOptions);

        $scope.markers = [];

        var infoWindow = new google.maps.InfoWindow();

        var createMarker = function (info) {

            var marker = new google.maps.Marker({
                map: $scope.map,
                position: new google.maps.LatLng(info.lat, info.long),
                title: info.city
            });
            marker.content = '<div class="infoWindowContent">' + info.desc + '</div>';

            google.maps.event.addListener(marker, 'click', function () {
                infoWindow.setContent('<h2>' + marker.title + '</h2>' + marker.content);
                infoWindow.open($scope.map, marker);
            });

            $scope.markers.push(marker);

        }

        for (i = 0; i < cities.length; i++) {
            createMarker(cities[i]);
        }

        $scope.openInfoWindow = function (e, selectedMarker) {
            e.preventDefault();
            google.maps.event.trigger(selectedMarker, 'click');
        }
    
    
})