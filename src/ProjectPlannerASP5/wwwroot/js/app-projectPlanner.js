// app-projects.js
(function () {

    angular.module("app", []);

    config.$inject = ['$routeProvider', '$locationProvider'];

    angular.module("app-projectPlanner", ["app", 'ngRoute',
        "simpleControls", 'summernote'])
        .config(config);

    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/views/index.html',
                controller: 'appController'
            })
            .when('/Projects', {
                templateUrl: '/views/projectsList.html',
                controller: 'projectsListController'
            })
            .when('/Projects/Details/:id', {
                templateUrl: '/views/projectDetails.html',
                controller: 'projectDetailsController'
            });

        $locationProvider.html5Mode(true);
    };
})();