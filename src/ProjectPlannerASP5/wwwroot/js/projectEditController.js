//projectEditController.js

(function () {

    angular.module('app')
        .controller('projectEditController', projectEditController);


    projectEditController.$inject = ['$scope', '$http', '$location', '$routeParams',
        'projectsService'];

    function projectEditController($scope, $http, $location, $routeParams, projectsService) {
        
        $scope.project = {
            createTimeStamp: new Date(),
            lastUpdateTimeStamp: new Date()
        };

        if ($routeParams.id !== 0)
        {
            $scope.project = projectsService.get({ id: $routeParams.id });
        }

        $scope.saveProject = function () {
            $http.post('/api/projects', $scope.project)
               .then(function (response) {
                   $location.path('/Projects/');
               }, function (error) {
                   alert('An error occurred');
               });
        };
    };
})();