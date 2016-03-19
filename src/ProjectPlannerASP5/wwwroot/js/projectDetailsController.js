//projectDetailsController.js

(function () {
    "use strict";

    angular.module("app")
        .controller("projectDetailsController", projectDetailsController);

    projectDetailsController.$inject = ['$scope', '$http', '$routeParams'];

    function projectDetailsController($scope, $http, $routeParams) {
        var vm = $scope;
        
        vm.project = {};

        $http.get("/api/projects/" + $routeParams.id + "/details")
          .then(function (response) {
              angular.copy(response.data, vm.project);
          },
          function (error) {

          })
          .finally(function () {

          });
        
        vm.getProjectStatusClass = function () {
            if (vm.project.status === "Active") {
                return "label label-primary";
            } else {
                return "label label-danger";
            }
        };
    };
})();