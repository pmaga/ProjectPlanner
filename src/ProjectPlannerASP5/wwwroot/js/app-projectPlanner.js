/// <reference path="../views/issue/issueedit.html" />
/// <reference path="../views/issue/issueedit.html" />
/// <reference path="../views/issue/issueedit.html" />
// app-projects.js
(function () {

    angular.module("app", []);

    config.$inject = ['$routeProvider', '$locationProvider'];

    angular.module("app-projectPlanner", ["app", 'ngRoute',
        "simpleControls", 'summernote', 'projectsServices',
        'issueServices'])
        .config(config);

    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/views/index.html'
            })
            .when('/Projects', {
                templateUrl: '/views/project/projectsList.html',
                controller: 'projectsListController'
            })
            .when('/Projects/Details/:id', {
                templateUrl: '/views/project/projectDetails.html',
                controller: 'projectDetailsController'
            })
            .when('/Projects/Create/', {
                templateUrl: '/views/project/projectEdit.html',
                controller: 'projectEditController'
            })
            .when('/Projects/Edit/:id', {
                templateUrl: '/views/project/projectEdit.html',
                controller: 'projectEditController'
            })
            .when('/Issues/:projectCode?', {
                templateUrl: '/views/issue/issuesList.html',
                controller: 'issueListController'
            })
            .when('/Issues/Create/:projectCode', {
                templateUrl: '/views/issue/issueEdit.html',
                controller: 'issueEditController'
            })
            .when('/Issues/Edit/:projectCode/:id', {
                templateUrl: '/views/issue/issueEdit.html',
                controller: 'issueEditController'
            })
        .otherwise({
            templateUrl: '/views/index.html'
        });

        $locationProvider.html5Mode(true);
    };
})();