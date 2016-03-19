// projectsListController.js

(function () {
    "use strict";

    angular.module("app")
		.controller("projectsListController", projectsListController);

    projectsListController.$inject = ['$scope', '$http', 'Project'];

    function projectsListController($scope, $http, Project) {
        
        $scope.projects = [];
        $scope.filteredProjects = [];
        $scope.errorMessage = "";
        $scope.isBusy = true;
        $scope.searchText = "";

        Project.query().$promise
            .then(function (response) {
                angular.copy(response, $scope.projects);
            },
            function (error) {
                $scope.errorMessage = "Failed to load data: " + error;
            })
            .finally(function() {
                $scope.isBusy = false;
            });

        $scope.deleteProject = function (project, index) {
            project.$delete(function () {
                $scope.projects.splice(index, 1);
            });
        };

        $scope.getStatusClass = function (status) {
            if (status === "Added")
                return "label label-primary";
            return "label";
        };
    }
})();