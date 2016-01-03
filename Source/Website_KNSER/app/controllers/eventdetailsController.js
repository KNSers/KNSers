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
}]);