'use strict';
var serviceBase = 'http://localhost:8248/';
//var serviceBase = 'http://knsersbackend.apphb.com/';
app.controller('requestsController', ['$scope', '$http', RequestController]);

function RequestController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;
    $scope.viewMode = false;
    $scope.disable = false;
    $scope.status = "text-danger";
    $scope.ApprovalStatus = false;
    $scope.name = '';

    // get all letter
    $http.get(serviceBase + "api/Requests/Get").success(function (data, status, headers, config) {
        $scope.requests = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });


    // approval 
    $scope.approval = function () {
        $scope.loading = true;
        var frien = this.request;
        frien.approval = true;
        
        $http.put(serviceBase + 'api/Requests/' + frien.requestid, frien).success(function (data) {
            $scope.ApprovalStatus = true;
            alert("Đã duyệt đơn bạn " + frien.fullname);
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.ApprovalStatus = "Xảy ra lỗi trong quá trình duyệt đơn " + data;
            $scope.loading = false;
        });
    };

    // cancel approval
    $scope.cancel = function () {
        $scope.loading = true;
        var frien = this.request;
        frien.approval = false;
        $http.put(serviceBase + 'api/Requests/' + frien.requestid, frien).success(function (data) {
            $scope.ApprovalStatus = true;
            alert("Đã hủy duyệt đơn bạn " + frien.fullname);
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.ApprovalStatus = "Xảy ra lỗi trong quá trình duyệt đơn " + data;
            $scope.loading = false;
        });
    };
}