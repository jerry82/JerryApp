(function () {
    'use strict';
    var app = angular.module('app', []);
    app.controller('titlesController', ['$scope', '$http', '$sce', titlesController]);

    function titlesController($scope, $http) {

        $scope.errors = null;

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
            alert(model.TitleId);

            $http.get('/api/Titles/' + model.TitleId).success(function (data) {
                $scope.detailShow = true;

                $scope.SelectedTitle = data;
            })
            .error(function (error) {
                $scope.errors = parseErrors(error);
            });
        }

        $scope.searchTitle = function () {
            $scope.detailShow = false;
            $http.get('/api/Titles/', { params: { keyword: $scope.keyword } }).success(function (data) {
                $scope.titleNames = data;
            })
            .error(function (error) {
                $scope.errors = parseErrors(error);
            });
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