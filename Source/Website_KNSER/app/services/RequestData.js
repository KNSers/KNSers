'use strict'
//app.factory('Requests', ['$resource', function () {
//       'use strict';
//       alert('tao don tu');
//       //return $resource('/api/Letter/Create');
//   }])
app.factory('RequestStream', ['$rootScope', function ($rootScope) {
       return {
           on: function (eventName, callback) {
               var connection = $.hubConnection();
               var requestHubProxy = connection.createHubProxy('requestHub');
               //alert('request Hub');
               requestHubProxy.on(eventName, function () {
                   var args = arguments;
                   $rootScope.$apply(function () {
                       alert('apply');
                       callback.apply(requestHubProxy, args);
                   });
               });

               connection.start().done(function () { });

           }
       };
   }]);