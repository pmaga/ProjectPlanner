/// <reference path="../../views/issues/edit.cshtml" />
/// <reference path="../../views/issues/edit.cshtml" />
// issueListController.js
(function () {

    "use strict";

    angular.module("app")
        .controller("issueListController", issueListController);

    issueListController.$inject = ['$http', '$scope', 'Project', 'Issue'];

    function issueListController($http, $scope, Project, Issue) {

        $scope.issues = [];
        $scope.errorMessage = "";
        $scope.isBusy = true;

        $scope.project = {};
        $scope.projects = Project.getLookups();
        $scope.isProjectChoosen = false;

        $scope.selectOptions = {
            onSelect: function (project) {
                $scope.project = project;
                $scope.isProjectChoosen = true;

                $scope.loadIssues(project.code);
            }
        };

        $scope.loadIssues = function(projectCode) {
            Issue.query({ projectCode: projectCode}).$promise
                .then(function (response) {
                    angular.copy(response, $scope.issues);
                }, function (error) {
                    $scope.errorMessage = 'Failed to load issues list ' + error;
                })
                .finally(function() {
                    $scope.isBusy = false;
                });
        };






        $scope.getStatusClass = function (status) {

            if (status === "Added") {
                return "label label-primary";
            } else if (status === "Modified") {
                return "label label-warning";
            }
        };
    }
})();