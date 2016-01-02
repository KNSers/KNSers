'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.orders = [];
    ordersService.getOrders().then(function (results) {
        alert(results.data);
        $scope.orders = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);