//projectViewController.js

(function () {
    "use strict";

    angular.module("app")
        .controller("projectViewController", projectViewController);

    function projectViewController($http) {

        var vm = this;

        vm.project = {};

        $http.get("api/projects/" + vm.projectId + "/details")
            .then(function (response) {
                angular.copy(response.data, vm.project)
            },
            function (error) {

            })
            .finally(function() {

            });

        vm.setProjectId = function(id) {
            vm.project.id = id;
        };
    };
})();