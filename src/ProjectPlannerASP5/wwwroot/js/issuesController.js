/// <reference path="../../views/issues/edit.cshtml" />
/// <reference path="../../views/issues/edit.cshtml" />
// issuesController.js
(function () {

    "use strict";

    angular.module("app")
        .controller("issuesController", issuesController);

    function issuesController($http) {
        var vm = this;

        vm.issues = [];
        vm.issue = {
            createDate: new Date()
        };
        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/projects/jrs/issues")
            .then(function (response) {
                angular.copy(response.data, vm.issues);

            }, function (error) {
                vm.errorMessage = "Failed to load data: " + error;
            })
            .finally(function(){
                vm.isBusy = false;
            });

        vm.getStatusClass = function (status) {

            if (status === "Added") {
                return "label label-primary";
            } else if (status === "Modified") {
                return "label label-warning";
            }
        };

        vm.saveIssue = function ($window) {
            $window.alert(vm.issue.summary);



        };
    }
})();