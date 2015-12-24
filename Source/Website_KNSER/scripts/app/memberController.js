var app  = angular.module('MemberApp', [])
   .controller('memberController', function ($scope, $http) {
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
