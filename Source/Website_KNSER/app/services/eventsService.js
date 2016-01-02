'use strict';
app.factory('eventsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var eventsServiceFactory = {};

    var _getEvents = function () {
        return $http.get(serviceBase + "api/Events/Get").then(function (results) {
            return results;
        });
    };
    var EventId = [];

    var _setEventDetails = function (id) {
        EventId = id;
        //alert(EventId);
    }

    var _getEventDetails = function () {
        return $http.get(serviceBase + "api/Events/" + EventId).then(function (results) {
            return results;
        })
    };
   


    //eventsServiceFactory.setEventDetails = _setEventDetails;
    eventsServiceFactory.getEvents = _getEvents;
    eventsServiceFactory.getEventDetails = _getEventDetails;
    eventsServiceFactory.setEventDetails = _setEventDetails;
    return eventsServiceFactory;

}]);