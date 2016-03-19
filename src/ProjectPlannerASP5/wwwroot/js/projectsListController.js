// projectsListController.js

(function () {
    "use strict";

    angular.module("app")
		.controller("projectsListController", projectsListController);

    projectsListController.$inject = ['$scope', '$http'];

    function projectsListController($scope, $http) {
        
        $scope.projects = [];
        $scope.filteredProjects = [];
        $scope.errorMessage = "";
        $scope.isBusy = true;
        $scope.searchText = "";

        $http.get("/api/projects/all")
			.then(function (response) {
			    angular.copy(response.data, $scope.projects);
			},
			function (error) {
			    $scope.errorMessage = "Failed to load data: " + error;
			})
            .finally(function () {
                $scope.isBusy = false;
            });

        $scope.getStatusClass = function (status) {
            if (status === "Added")
                return "label label-primary";
            return "label";
        };
    }
})();