//clientsListController.js
(function() {
    "use strict";

    angular.module('app')
        .controller('clientsListController', clientsListController);

    clientsListController.$inject = ['Client', '$scope'];


    function clientsListController(Client, $scope) {

        $scope.clients = [];
        $scope.filteredClients = [];
        $scope.errorMessage = "";
        $scope.isBusy = true;
        $scope.searchText = "";

        Client.query().$promise
            .then(function (response) {
                angular.copy(response, $scope.clients);
            },
            function (error) {
                $scope.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                $scope.isBusy = false;
            });

        $scope.deleteClient = function (client) {
            project.$delete(function () {
                var index = $scope.issues.indexOf(issue);
                $scope.projects.splice(index, 1);
            });
        };

        $scope.getStatusClass = function (status) {
            if (status === "Added")
                return "label label-primary";
            return "label";
        };
    };
})();