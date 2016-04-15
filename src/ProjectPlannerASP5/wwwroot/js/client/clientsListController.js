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

        $scope.selectedClient = {};

        Client.query().$promise
            .then(function (response) {
                angular.copy(response, $scope.clients);

                if ($scope.clients.length > 0) {
                    $scope.loadClientDetails($scope.clients[0].id);
                }
            },
            function (error) {
                $scope.errorMessage = "Failed to load data: " + error;
            })
            .finally(function () {
                $scope.isBusy = false;
            });

        $scope.deleteClient = function (client) {
            client.$delete(function () {
                var index = $scope.clients.indexOf(client);
                $scope.clients.splice(index, 1);
            });
        };

        $scope.loadClientDetails = function(clientId) {
            $scope.selectedClient = Client.getDetails({ id: clientId });
        };


        $scope.getStatusClass = function (status) {
            if (status === "Active")
                return "label label-primary";
            else if (status === "InActive") {
                return "label label-danger";
            }
            return "label";
        };
    };
})();