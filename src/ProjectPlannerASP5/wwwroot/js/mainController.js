(function () {
    "use strict";

    angular.module('app')
        .controller('mainController', mainController);

    mainController.$inject = ['$scope, $location'];

    function mainController($scope, $location) {

        var pages = ["Projects", "Issues"];
        var selectedPage = "";

        $scope.selectPage = function (pageName) {
            
        };

        $scope.isSelected = function (module) {
            if ($location.url() === module) {
                return true;
            } else {
                return false;
            }
        };
        

    }
})();