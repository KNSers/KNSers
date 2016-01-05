var serviceBase = 'http://localhost:8248/';
//var serviceBase = 'http://knsersbackend.apphb.com/';

'use strict';
app.controller('eventdetailsController', ['$scope', '$location', 'eventsService', 'ngAuthSettings', function ($scope, $location, eventsService, ngAuthSettings) {

    $scope.memberMode = true;
    $scope.scoreMode = true;
    $scope.eventdetails = [];
    eventsService.getEventDetails().then(function (results) {
            $scope.eventdetails = results.data;
        }, function (error) {
            $location.path('/user/event');
        });
    $scope.memberdetails = function () {
        $scope.memberMode = !$scope.memberMode;
    };

    $scope.part = function () {
        alert("go");
        var EventId = this.eventdetails[0].eventId;
        //alert(EventId);
        $scope.loading = true;
        eventsService.participant(EventId);
        //$http.post(serviceBase + 'api/Events/Participant', EventId)
        //    .success(function (data) {
        //        alert("Hoàn tất");
        //        $scope.addMode = false;
        //        alert(data);
        //        //$scope.letters.push(data);
        //        $scope.loading = false;
        //    })
        //    .error(function (data) {
        //        $scope.loading = false;
        //        alert("Lỗi");
        //    });
    }   
}]);