angular.module('WhereToApp', ['ngRoute', 'ngResource'])
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

    

    // Got filter from Angular-UI from https://github.com/angular-ui/ui-utils/blob/master/modules/unique/unique.js //
    .filter('unique', ['$parse', function ($parse) {
        'use strict';

        return function (items, filterOn) {

            if (filterOn === false) {
                return items;
            }

            if ((filterOn || angular.isUndefined(filterOn)) && angular.isArray(items)) {
                var newItems = [],
                  get = angular.isString(filterOn) ? $parse(filterOn) : function (item) { return item; };

                var extractValueToCompare = function (item) {
                    return angular.isObject(item) ? get(item) : item;
                };

                angular.forEach(items, function (item) {
                    var isDuplicate = false;

                    for (var i = 0; i < newItems.length; i++) {
                        if (angular.equals(extractValueToCompare(newItems[i]), extractValueToCompare(item))) {
                            isDuplicate = true;
                            break;
                        }
                    }
                    if (!isDuplicate) {
                        newItems.push(item);
                    }

                });
                items = newItems;
            }
            return items;
        }
    }])


.controller('ViewCtrl', function ($scope, placeRepository, $location) {
    $scope.places = placeRepository.get();
    $scope.Completed = function (place) {
        place.isCompleted = true;
        placeRepository.update(place);
    }
    $scope.$apply();
    $location.path("/ViewDestination");

   
})

.controller('EditCtrl', function ($location, $routeParams, placeRepository, $scope, $http) {
    var id = $routeParams.id;
    $http.get('/api/place/' + id)
    .success(function (data) {
        $scope.Detail = data[0];
        console.log(data);
        console.log($scope.Detail);
    })
    .error(function (err) {
        console.log(err);
    });

    $scope.updateDetails = function (Detail) {
        placeRepository.updateDetails(Detail);
       
    }
        

    //setTimeout(function () {
    //    var service = new google.maps.places.PlacesService($rootScope.map);

    //    service.getDetails({ placeId: id }, function (Locdetail, status) {
    //        console.log(Locdetail, status);
    //        vm.Detail = Locdetail;
    //        console.log(vm.Detail.name);
    //    })
    //}, 5000)
    

    

})

.controller('PlaceCtrl', function ($rootScope, $scope, placeRepository, $location) {
    $scope.places = placeRepository.get();

    $scope.save = function(place) {
        placeRepository.save(place);
        $scope.$apply();
        $location.path("/ViewDestination");
       
        
        
    }
    
    //Taken from Google Place Finder documentation: https://developers.google.com/maps/documentation/javascript/examples/places-placeid-finder
    $scope.mapstart = function initialize() {
        var mapOptions = {
            center: { lat: -33.8688, lng: 151.2195 },
            zoom: 13
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
                'Place ID: ' + place.place_id + '<br>' +
                place.formatted_address + '<br><button class="add-map">Add to Destination</button>');
            infowindow.open(map, marker);

            $(".add-map").click(function () {
                $("#destination").val(place.place_id).trigger("input");
                $("#placeName").val(place.name).trigger("input");
                $("#placeAddress").val(place.formatted_address).trigger("input");
                console.log(place.place_id);    
            })

        });
    }

    google.maps.event.addDomListener(window, 'load', $scope.mapstart);
})
