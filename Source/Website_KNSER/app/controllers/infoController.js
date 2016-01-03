'use strict'
var serviceBase = 'http://localhost:8248/';
//var serviceBase = 'http://knsersbackend.apphb.com/';
app.controller('infoController', ['$scope', '$http', InfoController]);

//angularjs controller method
function InfoController($scope, $http) {
    $scope.loading = true;
    $scope.editMode = true;
    $scope.LetterIdSelected = '1';
    //$scope.data.letterid = null;
    //alert("access");
    // get all events
    $http.get(serviceBase + "api/Account/Infomation").success(function (data, status, headers, config) {
        $scope.info = data;
        //alert(data);
        $scope.loading = false;
    })
    .error(function () {
        alert("not get");
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.enableEdit = function () {
        $scope.editMode = !$scope.editMode;
    };

    $scope.confirm = function () {
        alert("Thay đổi dữ liệu thành công!");
    }
}