'use strict'
var serviceBase = 'http://localhost:8248/';
//var serviceBase = 'http://knsersbackend.apphb.com/';
app.controller('contactController', ['$scope', '$http', ContactController]);

//angularjs controller method
function ContactController($scope, $http) {
    $scope.loading = true;
    $scope.editMode = true;
    //$scope.LetterIdSelected = '1';
}