//projectViewController.js

(function () {
    "use strict";

    angular.module("app")
        .controller("projectViewController", projectViewController);

    function projectViewController($http) {

        var vm = this;

        vm.project = {};

        vm.loadProject = function(id) {
            vm.project.id = id;
            $http.get("/api/projects/" + vm.project.id + "/details")
              .then(function (response) {
                  angular.copy(response.data, vm.project);
              },
              function (error) {

              })
              .finally(function () {

              });
        };

        vm.getProjectStatusClass = function () {
            if (vm.project.status === "Active") {
                return "label label-primary";
            } else {
                return "label label-danger";
            }
        };
    };
})();