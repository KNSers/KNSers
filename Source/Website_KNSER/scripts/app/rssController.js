
//var app = angular.module('RssFeed', [])

var app = angular.module('RssApp', [])
app.controller('RssEventController', ['$scope', '$http', RssEventController]);

function RssEventController($scope, $http) {
    $scope.answered = false;
    $scope.title = "loading rss feed...";
    $scope.correctAnswer = false;
    $scope.working = false;

    $http.get("http://localhost:8248/api/RssFeed/rss").success(function (data, status, headers, config) {
        $scope.options = data;
        $scope.title = "Rss FIT";
    }).error(function (data, status, headers, config) {
        $scope.title = "Oops... something went wrong";
        $scope.working = false;
    });
}

app.controller('memberController', function ($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    $http.get("http://localhost:8248/api/members").success(function (data) {
        $scope.members = data;
        $scope.loading = false;
    })
 .error(function () {
     $scope.error = "Oops!";
     $scope.loading = false;
 });

    $scope.toggleEdit = function () {
        this.member.editMode = !this.member.editMode;
    };

    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };
    
});


