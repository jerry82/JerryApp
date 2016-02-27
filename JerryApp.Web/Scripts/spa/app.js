/// <reference path="../vendors/angular.js" />

'use strict';
angular.module('app', ['ngRoute'])
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider.
                when('/TitleSearch', {
                    templateUrl: 'scripts/spa/Titles/TitleSearch.html',
                    controller: 'titleSearchController'
                }).
                when('/', {
                    templateUrl: 'scripts/spa/Main.html',
                    controller: ''
                }).
                otherwise({
                    redirectTo: '/'
                });
        }]);
