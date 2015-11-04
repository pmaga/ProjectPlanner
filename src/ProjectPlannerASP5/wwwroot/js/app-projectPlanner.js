// app-projects.js
(function () {

    angular.module("projectsModule", ["ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "projectsController",
                controllerAs: "vm",
                templateUrl: "/views/projectsView.html"
            });

            $routeProvider.otherwise({
                redirectTo: "/"
            });
        });

    angular.module("issuesModule", ["ngRoute"])
        .config(function ($routeProvider) {
            //$routeProvider.when("/", {
            //    controller: "issuesController",
            //    controllerAs: "vm",
            //    templateUrl: "/views/issuesView.html"
            //});

            //$routeProvider.otherwise({
            //    redirectTo: "/"
            //});
        });

    angular.module("app-projectPlanner", ["projectsModule", "issuesModule",
        "simpleControls", "ngRoute"]);
})();