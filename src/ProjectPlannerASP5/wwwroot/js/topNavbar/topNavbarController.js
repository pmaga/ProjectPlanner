//topNavbarController.js
(function() {

    angular.module('app')
        .controller('topNavbarController', topNavbarController);

    topNavbarController.$inject = ['$scope'];

    function topNavbarController($scope) {
        $scope.isAuthenticated = true;
    };
})();