'use strict';
var serviceBase = 'http://localhost:8248/';
//var serviceBase = 'http://knsersbackend.apphb.com/';
app.controller('requestRealtimeController', ['$scope','RequestStream', '$http', RequestRealtimeController]);

function RequestRealtimeController($scope, RequestStream, $http) {
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
    // Realtime
    RequestStream.on('addNewRequest', function (newRequest) {
        $scope.requests.push(newRequest);
        alert('push');
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

app.filter('reverse', function () {
    return function (items) {
        return items.slice().reverse();
    };
});
