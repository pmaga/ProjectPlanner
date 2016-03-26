//projectEditController.js

(function () {

    angular.module('app')
        .controller('projectEditController', projectEditController);

    projectEditController.$inject = ['$scope', '$http', '$location', '$routeParams',
        'Project'];

    function projectEditController($scope, $http, $location, $routeParams, Project) {

        if ($routeParams.id > 0) {
            $scope.project = Project.get({ id: $routeParams.id });
        } else {
            $scope.project = new Project();
            $scope.project.id = 0;
            $scope.project.createTimeStamp = new Date();
            $scope.project.lastUpdateTimeStamp = new Date();
        }

        $scope.saveProject = function () {
            alert($scope.project.id);
            if ($scope.project.id === 0) {
                $scope.project.$save(function () {
                    $location.path('/Projects/');
                });
            } else {
                $scope.project.$update(function () {
                    $location.path('/Projects/');
                });
            }
        };

        $scope.cancelEdit = function () {
            $location.path('/Projects/');
        };
    };
})();