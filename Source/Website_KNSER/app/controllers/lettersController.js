'use strict'
var serviceBase = 'http://localhost:8248/';
//var serviceBase = 'http://knsersbackend.apphb.com/';
app.controller('lettersController', ['$scope', '$http', LetterController]);

//angularjs controller method
function LetterController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;
    $scope.buttonmode = true;
    $scope.enddatemode = false;
    $scope.LetterIdSelected = '1';
    //$scope.data.letterid = null;

    // get all letter
    $http.get(serviceBase + "api/Letter/Get").success(function (data, status, headers, config) {
        $scope.letters = data;
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

    $scope.changedValue = function (item) {
        if (item.letterId == '2') {
            $scope.enddatemode = true;
        }
        else {
            $scope.enddatemode = false;
        }
        $scope.buttonmode = false;
        $scope.LetterIdSelected = item.letterId;
    }

    // insert letter
    $scope.add = function () {
        $scope.loading = true;
        this.NewRequest.LetterId = $scope.LetterIdSelected;
        //alert(this.NewRequest.startdate);
        $http.post(serviceBase + 'api/Letter/Create', this.NewRequest)
            .success(function (data) {
                alert("Hoàn tất");
                $scope.addMode = false;
                $scope.letters.push(data);
                $scope.loading = false;
            })
            .error(function (data) {
                $scope.error = "Xảy ra lỗi trong quá trình tạo đơn " + data;
                $scope.loading = false;
                alert("Lỗi");
            });
    };
}