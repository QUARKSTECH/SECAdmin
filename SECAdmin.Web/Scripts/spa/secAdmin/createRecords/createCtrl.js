(function (app) {
    'use strict';

    app.controller('createCtrl', createCtrl);

    createCtrl.$inject = ['$scope', 'membershipService', 'notificationService', '$rootScope', '$location', '$routeParams','apiService'];

    function createCtrl($scope, membershipService, notificationService, $rootScope, $location, $routeParams, apiService) {

        $scope.createObj = {
            studentId: $routeParams.id,
            studentRecordsVm: {}
        }

        //default on load
        $scope.$on('$viewContentLoaded', function (a) {
            if ($scope.createObj.studentId!=null) {
                getStudentRecordsById($scope.createObj.studentId)
            }
        });

        $scope.create = function () {
            saveStudentsData();
        }

        function saveStudentsData () {
            apiService.post('api/student/savestudentsdata', $scope.createObj.studentRecordsVm, Success, Failed);
        }

        function Success (response) {
            $scope.createObj.studentRecordsVm = {};
            notificationService.displaySuccess("Records saved successfully");
        }

        function Failed() {
            notificationService.displayError("Something went wrong. Please try again.");
        }

        function getStudentRecordsById(studentId) {
            apiService.post('api/student/saveStudentsData', studentId, getStudentDataSuccess, Failed);
        }

        function getStudentDataSuccess(response) {
            $scope.createObj.studentRecordsVm = response;
        }
    }

})(angular.module('secAdmin'));