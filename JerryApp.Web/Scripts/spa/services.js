angular.module('app').factory('utilService', ['$location', '$anchorScroll', function ($location, $anchorScroll) {

    return {
        convert: function (input) {
            return input ? '\u2713' : '\u2718';
        },
        parseErrors: function (response) {
            var errors = [];
            for (var key in response.ModelState) {
                if (key == '$id') continue;
                for (var i = 0; i < response.ModelState[key].length; i++) {
                    errors.push(response.ModelState[key][i]);
                }
            }
            return errors;
        },
        scrollToDetail: function(divName) {
            var id = $location.hash();
            $location.hash(divName);
            $anchorScroll();
            $location.hash(id);
        }
    }
}]);