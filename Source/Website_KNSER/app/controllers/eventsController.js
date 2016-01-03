'use strict';
app.controller('eventsController', ['$scope', 'eventsService', function ($scope, eventsService) {

    $scope.events = [];
    eventsService.getEvents().then(function (results) {
        $scope.events = results.data;

    }, function (error) {
        alert("Xảy ra lỗi lấy dữ liệu");
    });
    $scope.eventdetails = [];
    $scope.viewDetails = function () {
        //alert(this.event.eventId);
        // gắn dữ liệu qua eventService để page eventdetails lấy dữ liệu
        eventsService.setEventDetails(this.event.eventId);
    };

    
    
    
}]);