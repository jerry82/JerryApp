(function () {
    'use strict';
    var app = angular.module('app', []);
    app.controller('titlesController', ['$scope', '$http', '$sce', titlesController]);

    function titlesController($scope, $http) {

        $scope.errors = null;
        $scope.gettingDetail = false;
        $scope.searching = false; 

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

            })
            .error(function (error) {
                // $scope.errors = parseErrors(error);
                $scope.errors = error.Message;
                $scope.gettingDetail = true;
            });
        }

        $scope.searchTitle = function () {
            $scope.detailShow = false;
            if ($scope.keyword) {
                $scope.errors = undefined;
                $scope.searching = true;
                $http.get('/api/Titles/', { params: { keyword: $scope.keyword } }).success(function (data) {
                    $scope.titleNames = data;
                    $scope.searching = false;
                })
                .error(function (error) {
                    $scope.errors = error.Message;
                    $scope.searching = false;
                    //$scope.errors = parseErrors(error);
                });
            }
            else {
                $scope.errors = "Please provide 'keyword'";
            }
        }

        $scope.checkmark = function (input) {
            return input ? '\u2713' : '\u2718';
        }

        //helpers
        function parseErrors(response) {
            var errors = [];
            for (var key in response.ModelState) {
                for (var i = 0; i < response.ModelState[key].length; i++) {
                    errors.push(response.ModelState[key][i]);
                }
            }
            return errors;
        }
    }
})();