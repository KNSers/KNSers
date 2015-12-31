'use strict';
app.controller('activityController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('index.html#/home');
    }

    $scope.authentication = authService.authentication;

}]);