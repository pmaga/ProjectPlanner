// projectsController.js

(function () {

	"use strict";

	angular.module("app-projects")
		.controller("projectsController", projectsController);

	function projectsController($http) {

		var vm = this;

		vm.projects = [];

		$http.get("api/projects")
			.then(function (response) {

			angular.copy(response.data, vm.projects);
			},
			function () {

			});

		vm.getStatusClass = function (status) {
		    if (status === "Active")
		        return "label label-primary";
		}
	}

})();