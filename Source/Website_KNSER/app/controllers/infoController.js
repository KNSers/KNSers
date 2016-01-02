'use strict'
var serviceBase = 'http://localhost:8248/';
//var serviceBase = 'http://knsersbackend.apphb.com/';
app.controller('infoController', ['$scope', '$http', InfoController]);

//angularjs controller method
function InfoController($scope, $http) {
    $scope.loading = true;
    $scope.studentmode = true;
    $scope.enddatemode = false;
    $scope.LetterIdSelected = '1';
    //$scope.data.letterid = null;

    // get all events
    $http.get(serviceBase + "api/Events/Get").success(function (data, status, headers, config) {
        $scope.events = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.student.editMode = !this.student.editMode;
    };

    $scope.toggleView = function () {
        this.student.viewMode = !this.student.viewMode;
    }
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    $scope.openMember = function () {
        $scope.studentmode = !$scope.studentmode;
    };
}