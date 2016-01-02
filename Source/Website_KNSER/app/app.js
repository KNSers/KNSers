
var app = angular.module('AngularAuthApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

    $routeProvider.when("/refresh", {
        controller: "refreshController",
        templateUrl: "/app/views/refresh.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/views/associate.html"
    });


    $routeProvider.when("/admin/IndexRequest", {
        controller: "requestsController",
        templateUrl: "/app/views/admin/IndexRequest.html"
    });

    $routeProvider.when("/user/request", {
        controller: "requestsController",
        controller: "lettersController",
        templateUrl: "/app/views/user/request.html"
    });

    $routeProvider.when("/user/rss", {
        controller: "rsseventController",
        templateUrl: "/app/views/user/rss.html"
    });

    $routeProvider.when("/user/event", {
        controller: "eventsController",
        templateUrl: "/app/views/user/event.html"
    });

    $routeProvider.when("/user/infomation", {
        controller: "infoController",
        templateUrl: "/app/views/user/infomation.html"
    });

    $routeProvider.when("/user/eventdetails", {
        controller: "infoController",
        templateUrl: "/app/views/user/eventdetails.html"
    });


    $routeProvider.otherwise({ redirectTo: "/home" });

});

var serviceBase = 'http://localhost:8248/';
//var serviceBase = 'http://knsersbackend.apphb.com/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


