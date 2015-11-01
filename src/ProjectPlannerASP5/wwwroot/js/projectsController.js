// projectsController.js

(function () {

    "use strict";

    angular.module("app-projects")
		.controller("projectsController", projectsController);

    function projectsController($http) {

        var vm = this;

        vm.projects = [];
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("api/projects")
			.then(function (response) {
			    angular.copy(response.data, vm.projects);
			},
			function (error) {
			    vm.errorMessage = "Failed to load data: " + error;
			})
            .finally(function () {
                vm.isBusy = false;
            });

        vm.getStatusClass = function (status) {
            if (status === "Active")
                return "label label-primary";
        }
    }

})();