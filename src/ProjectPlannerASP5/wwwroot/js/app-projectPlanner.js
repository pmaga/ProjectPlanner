// app-projects.js
(function () {

    angular.module("app", []);

    config.$inject = ['$routeProvider', '$locationProvider'];

    angular.module("app-projectPlanner", ["app", 'ngRoute',
        "simpleControls", 'summernote', 'projectsServices'])
        .config(config);

    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/views/index.html',
                controller: 'mainController'
            })
            .when('/Projects', {
                templateUrl: '/views/projectsList.html',
                controller: 'projectsListController'
            })
            .when('/Projects/Details/:id', {
                templateUrl: '/views/projectDetails.html',
                controller: 'projectDetailsController'
            })
            .when('/Projects/Create/', {
                templateUrl: '/views/projectEdit.html',
                controller: 'projectEditController'
            })
            .when('/Projects/Edit/:id', {
                templateUrl: '/views/projectEdit.html',
                controller: 'projectEditController'
            })
        .otherwise({
            templateUrl: '/views/index.html',
            controller: 'mainController'
        });;

        $locationProvider.html5Mode(true);
    };
})();