angular.module('WhereToApp')
.factory('placeRepository', function ($resource) {
    return {
        get: function () {
            return $resource('/api/place').query();
        },
    
        save: function (place) {
            return $resource('/api/place').save(place);
        }
    }
});