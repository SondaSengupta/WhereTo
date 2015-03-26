angular.module('WhereToApp')
.factory('placeRepository', function ($resource) {
    //Refactor duplicate code of get query
    return {
        get: function () {
            return $resource('/api/place').query();
        },

        getAll: function(){
            return $resource('api/place/all').query();
        },

        save: function (place) {
            $resource('/api/place').save(place);
            return $resource('/api/place').query();
        },
        getPlaceId: function (id) {
            $resource('/api/place/' + id).query();
            return $resource('/api/place').query();
        },
        updateDetails: function (place) {
            $resource('api/' + place.id + '/update').save(place);
            return $resource('/api/place').query();
        }
    }
});