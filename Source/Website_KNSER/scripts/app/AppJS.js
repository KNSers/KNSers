
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


    // get all student
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

    // insert student
    $scope.add = function () {
        $scope.loading = true;
        $http.post('http://localhost:2371/api/StudentApi', this.newstudent)
            .success(function (data) {
                alert("Add Successfully!");
                $scope.addMode = false;
                $scope.students.push(data);
                $scope.loading = false;
            })
            .error(function (data) {
                $scope.error = "An Error has occured while Adding Student! " + data;
                $scope.loading = false;
            });
    };

    //Delete Student
    $scope.deletestudent = function () {
        $scope.loading = true;
        var Id = this.student.StudentId;
        $http.delete('http://localhost:2371/api/student/delete/?id=' + Id).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.students, function (i) {
                if ($scope.students[i].StudentId === Id) {
                    $scope.students.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Student! " + data;
            $scope.loading = false;

        });
    };


    //Edit Student
    $scope.save = function () {
        alert("Edit");
        $scope.loading = true;
        var frien = this.student;
        alert(frien);
        $http.put('http://localhost:2371/api/StudentApi/' + frien.StudentId, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Student! " + data;
            $scope.loading = false;
        });
    };
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