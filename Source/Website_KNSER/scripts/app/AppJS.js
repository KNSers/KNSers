
//var app = angular.module('RssFeed', [])

var app = angular.module('App', [])
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


app.controller('LetterController', ['$scope', '$http', LetterController]);

//angularjs controller method
function LetterController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;
    $scope.viewMode = false;
    $scope.data.letterid = null;

    // get all letter
    $http.get("http://localhost:8248/api/Letter/get").success(function (data, status, headers, config) {
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

    // insert letter
    $scope.add = function () {
        $scope.loading = true;
        alert('aa');
        alert(data.letterid);
        //this.NewRequest.letterid = letterid;
        //alert(this.NewRequest.letterid);
        $http.post('http://localhost:8248/api/Letter/Create', this.NewRequest)
            .success(function (data) {
                alert("Hoàn tất");
                $scope.addMode = false;
                $scope.letters.push(data);
                $scope.loading = false;
            })
            .error(function (data) {
                $scope.error = "Xảy ra lỗi trong quá trình tạo đơn " + data;
                $scope.loading = false;
            });
    };

    ////Delete Student
    //$scope.deleteletter = function () {
    //    $scope.loading = true;
    //    var Id = this.student.StudentId;
    //    $http.delete('http://localhost:2371/api/student/delete/?id=' + Id).success(function (data) {
    //        alert("Deleted Successfully!!");
    //        $.each($scope.students, function (i) {
    //            if ($scope.students[i].StudentId === Id) {
    //                $scope.students.splice(i, 1);
    //                return false;
    //            }
    //        });
    //        $scope.loading = false;
    //    }).error(function (data) {
    //        $scope.error = "An Error has occured while Saving Student! " + data;
    //        $scope.loading = false;

    //    });
    //};


    ////Edit Student
    //$scope.save = function () {
    //    alert("Edit");
    //    $scope.loading = true;
    //    var frien = this.student;
    //    alert(frien);
    //    $http.put('http://localhost:2371/api/StudentApi/' + frien.StudentId, frien).success(function (data) {
    //        alert("Saved Successfully!!");
    //        frien.editMode = false;
    //        $scope.loading = false;
    //    }).error(function (data) {
    //        $scope.error = "An Error has occured while Saving Student! " + data;
    //        $scope.loading = false;
    //    });
    //};
}

//member
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



app.controller('RequestController', ['$scope', '$http', RequestController]);

function RequestController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;
    $scope.viewMode = false;
    $scope.disable = false;
    $scope.status = "text-danger";
    $scope.ApprovalStatus = false;
    $scope.name = '';
    
    // get all letter
    $http.get("http://localhost:8248/api/Requests/Get").success(function (data, status, headers, config) {
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
        alert(frien);
        $http.put('http://localhost:8248/api/Requests/' + frien.requestid, frien).success(function (data) {
            $scope.ApprovalStatus = true;
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
        alert(frien);
        $http.put('http://localhost:8248/api/Requests/' + frien.requestid, frien).success(function (data) {
            $scope.ApprovalStatus = true;
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.ApprovalStatus = "Xảy ra lỗi trong quá trình duyệt đơn " + data;
            $scope.loading = false;
        });
    };
}