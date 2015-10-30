// issuesController.js
(function () {

    "use strict";

    angular.module("app-projects")
        .controller("issuesController", issuesController);

    function issuesController($http) {
        var vm = this;

        vm.issues = [];

        $http.get("/api/projects/jrs/issues")
            .then(function (response) {
                // Success
                angular.copy(response.data, vm.issues);

            }, function () {
                //Failure

            });

        vm.getStatusClass = function (status) {

            if (status === "Added") {
                return "label label-primary";
            } else if (status === "Warning") {
                return "label label-warning";
            }

        };
    }
})();