//projectDetailsController.js

(function () {
    "use strict";

    angular.module("app")
        .controller("projectDetailsController", projectDetailsController);

    projectDetailsController.$inject = ['$scope', '$http', '$routeParams', 'projectsService'];

    function projectDetailsController($scope, $http, $routeParams, projectsService) {
        var vm = $scope;

        vm.project = {};

        vm.project = projectsService.getDetails({ id: $routeParams.id });

        vm.getProjectStatusClass = function () {
            if (vm.project.status === "Active") {
                return "label label-primary";
            } else {
                return "label label-danger";
            }
        };
    };
})();