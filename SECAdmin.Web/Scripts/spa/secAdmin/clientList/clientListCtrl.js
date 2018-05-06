(function (app) {
    'use strict';

    app.controller('clientListCtrl', clientListCtrl);

    clientListCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location'];

    function clientListCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.studentListVm = {

        };

        
    }

})(angular.module('secAdmin'));