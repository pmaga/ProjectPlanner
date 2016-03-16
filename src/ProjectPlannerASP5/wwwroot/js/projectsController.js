// projectsController.js

(function () {
    "use strict";

    angular.module("app")
		.controller("projectsController", projectsController);

    function projectsController($http, $location) {
        
        var vm = this;

        vm.projects = [];
        vm.filteredProjects = [];
        vm.errorMessage = "";
        vm.isBusy = true;
        vm.searchText = "";

        $http.get("/api/projects/all")
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
            if (status === "Added")
                return "label label-primary";
            return "label";
        };

        vm.editedProject = {};
        
        vm.loadProjectToEdit = function (id) {
            
            if (id === 0) {
                vm.editedProject.createTimeStamp = new Date();
                vm.editedProject.lastUpdateTimeStamp = new Date();
                return;
            }
            
            $http.get("/api/projects/" + id)
                .then(function (response) {
                    angular.copy(response.data, vm.editedProject);
                }, function (error) {

                })
                .finally(function () {
                     
                });
        }

        vm.saveProject = function () {
            $http.post('/api/projects', vm.editedProject)
               .then(function (response) {
                   $location.path('/Projects');
               }, function (error) {

               });
        }
    }
})();