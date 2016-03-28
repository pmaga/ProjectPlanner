/// <reference path="../../views/issues/edit.cshtml" />
/// <reference path="../../views/issues/edit.cshtml" />
// issueListController.js
(function () {

    "use strict";

    angular.module("app")
        .controller("issueListController", issueListController);

    issueListController.$inject = ['$http', '$scope', 'Project', 'Issue', '$routeParams'];

    function issueListController($http, $scope, Project, Issue, $routeParams) {

        $scope.issues = [];
        $scope.errorMessage = "";
        $scope.isBusy = true;

        $scope.project = {};
        $scope.issueStatuses = ['ToDo', 'InProgress', 'Completed'];
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

        $scope.deleteIssue = function (issue, index) {
            Issue.test({ id: issue.id, projectCode: $scope.project.code }).$promise
                .then(function () {
                $scope.issues.splice(index, 1);
            }, function(error) {

            });
        };

        $scope.getStatusClass = function (status) {

            if (status === "Added") {
                return "label label-primary";
            } else if (status === "Modified") {
                return "label label-warning";
            }
        };

        $scope.getIssueStateClass = function(issueState) {
            var result = "label ";

            if (issueState === "InProgress") {
                result += "label-warning";
            } else if (issueState === "Completed") {
                result += "label-success";
            }
            return result;
        };

        if ($routeParams.projectCode) {
            $scope.project.code = $routeParams.projectCode;
            $scope.loadIssues($routeParams.projectCode);
            $scope.isProjectChoosen = true;
        };
    }
})();