'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.selectedIndex = 0; // Whatever the default selected index is, use -1 for no selection

    $scope.itemClicked = function ($index) {
        $scope.selectedIndex = $index;
    };


    $scope.logOut = function () {
        authService.logOut();
        $location.path('index.html/home');
    }

    $scope.authentication = authService.authentication;

}]);