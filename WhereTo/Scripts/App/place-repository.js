angular.module('WhereToApp')
.factory('placeRepository', function ($resource) {

    return {
        get: function () {
            return $resource('/api/place').query();
        },

        getAll: function () {
            return $resource('api/place/all').query();
        },

        save: function (place) {
           return $resource('/api/place').save(place);
        },
        getPlaceId: function (id) {
           return $resource('/api/place/' + id).query();
        },
        updateDetails: function (place) {
           return $resource('api/' + place.id + '/update').save(place);
        }
    }
});