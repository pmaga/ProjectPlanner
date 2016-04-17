//clientEditController.js
(function() {

    angular.module('app')
        .controller('clientEditController', clientEditController);

    clientEditController.$inject = ['Client', '$scope', '$routeParams', '$location'];

    function clientEditController(Client, $scope, $routeParams, $location) {

        if ($routeParams.id > 0) {
            $scope.client = Client.get({ id: $routeParams.id });
        } else {
            $scope.client = new Client();
            $scope.client.id = 0;
            $scope.client.createTimeStamp = new Date();
            $scope.client.lastUpdateTimeStamp = new Date();
        }

        $scope.saveClient = function () {
            if ($scope.client.id === 0) {
                $scope.client.$save().then(function () {
                    $scope.goToClientList();
                });
            } else {
                $scope.client.$update().then(function () {
                    $scope.goToClientList();
                });
            }
        };

        $scope.cancelEdit = function () {
            $scope.goToClientList();
        };

        $scope.goToClientList = function () {
            $location.path('/Clients');
        };
    };
})();