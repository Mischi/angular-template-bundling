;(function (angular) {
    'use strict';

    var app = angular.module('template-bundle-demo', []);

    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeCtrl',
                templateUrl: 'Templates/home.html'
            })
            .when('/about', {
                controller: 'AboutCtrl',
                templateUrl: 'Templates/about.html'
            });
    }]);

    app.controller('HomeCtrl', ['$scope', function ($scope) {
        $scope.title = 'Home';
    }]);

    app.controller('AboutCtrl', ['$scope', function ($scope) {
        $scope.title = 'About';
    }]);

})(angular);