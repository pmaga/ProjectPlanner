//projectEditController.js

(function () {

    angular.module('app')
        .controller('projectEditController', projectEditController);


    projectEditController.$inject = ['$scope', '$http', '$location', '$routeParams',
        'Project'];

    function projectEditController($scope, $http, $location, $routeParams, Project) {
        
        if ($routeParams.id !== 0) {
            $scope.project = Project.get({ id: $routeParams.id });
        } else {
            $scope.project = new Project();
            $scope.project.createTimeStamp = new Date();
            $scope.project.lastUpdateTimeStamp = new Date();
        }

        $scope.saveProject = function () {
            $scope.project.$save(function () {
                $location.path('/Projects/');
            });


            //$http.post('/api/projects', $scope.project)
            //   .then(function (response) {
            //       $location.path('/Projects/');
            //   }, function (error) {
            //       alert('An error occurred');
            //   });
        };
    };
})();