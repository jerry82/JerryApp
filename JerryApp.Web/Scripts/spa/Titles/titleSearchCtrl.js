
'use strict';

angular.module('app').controller('titleSearchController', ['$scope', '$http', 'utilService', titleSearchController]);
function titleSearchController($scope, $http, utilService) {

    $scope.errors = null; 
    $scope.gettingDetail = false;
    $scope.searching = false;
    $scope.sortReverse = false; 

    $scope.getAllTitles = function() {
        $http.get('/api/Titles/')
        .success(function (data) {
            $scope.titles = data; 
        })
        .error(function () {
            $scope.errors = "An Error has occured while loading data!";
        });
    }

    $scope.getDetail = function (model) {

        $scope.gettingDetail = true;

        $http.get('/api/Titles/' + model.TitleId).success(function (data) {
            $scope.detailShow = true;
            $scope.SelectedTitle = data;
            $scope.gettingDetail = true;

            utilService.scrollToDetail('detailPanel');
        })
        .error(function (error) {
            $scope.errors = error.Message;
            $scope.gettingDetail = true;
        });
    }

    $scope.searchTitle = function () {
        $scope.detailShow = false;
        $scope.errors = undefined;
        $scope.searching = true;

        var searchData = {
            TitleKeyword: $scope.keyword
        };
        $http.post('/api/Titles/Search/', searchData).success(function (data) {
            $scope.titleNames = data;
            $scope.searching = false;
        })
        .error(function (modelState) {
            $scope.searching = false;
            $scope.errors = utilService.parseErrors(modelState);
        });
    }

    $scope.getParticipants = function (model) {
        $scope.participants = null;
        $http.get('/api/Titles/' + model.TitleId + '/Participants').success(function (data) {
            $scope.participants = data;
        })
        .error(function (error) {
            $scopes.errors = error;
        });
    }

    $scope.checkmark = function (input) {
        return utilService.convert(input);
    }

    $scope.sortData = function (col) {
        $scope.sortCol = col;
        $scope.sortReverse = !$scope.sortReverse;
    }
}
