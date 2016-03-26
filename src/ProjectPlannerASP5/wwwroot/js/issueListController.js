/// <reference path="../../views/issues/edit.cshtml" />
/// <reference path="../../views/issues/edit.cshtml" />
// issueListController.js
(function () {

    "use strict";

    angular.module("app")
        .controller("issueListController", issueListController);

    issueListController.$inject = ['$http', '$scope'];

    function issueListController($http, $scope) {

        $scope.issues = [];
        $scope.issue = {
            createDate: new Date()
        };
        $scope.errorMessage = "";
        $scope.isBusy = true;

        $scope.fruits = ['apple', 'orange', 'mango', 'grapefruit', 'banana', 'melon'];
        $scope.project = {};
        $scope.projects = [
            { id: 1, code: 'jrs', name: 'jars' },
            { id: 2, code: 'ath', name: 'Akademia Techncizno-Humoanistyczna' }
        ];

        $scope.selectOptions = {
            onSelect: function (project) {
                $scope.project = project;
                $scope.isProjectChoosen = true;
                //load issues list
            }
        };

        $scope.isProjectChoosen = false;













        $http.get("/api/projects/jrs/issues")
            .then(function (response) {
                angular.copy(response.data, $scope.issues);

            }, function (error) {
                $scope.errorMessage = "Failed to load data: " + error;
            })
            .finally(function(){
                $scope.isBusy = false;
            });

        $scope.getStatusClass = function (status) {

            if (status === "Added") {
                return "label label-primary";
            } else if (status === "Modified") {
                return "label label-warning";
            }
        };

       $scope.saveIssue = function () {

           
        };
    }
})();