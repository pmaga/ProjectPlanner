//homeController.js
(function() {

    angular.module('app')
        .controller('homeController', homeController);

    homeController.$inject = ['$scope', 'identityInfo'];

    function homeController($scope, identityInfo) {

        $scope.username = identityInfo.username;

    };
})();