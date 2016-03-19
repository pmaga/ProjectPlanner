//projectEditController.js

(function () {

    angular.module('app')
        .controller('projectEditController', projectEditController);


    projectEditController.$inject = ['$scope', '$http', '$location', '$routeParams'];

    function projectEditController($scope, $http, $location, $routeParams) {
        
        $scope.project = {
            createTimeStamp: new Date(),
            lastUpdateTimeStamp: new Date()
        };

        if ($routeParams.id !== 0)
        {
            $http.get('/api/projects/' + $routeParams.id)
              .then(function (response) {
                  angular.copy(response.data, $scope.project);
              }, function (error) {
          });
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