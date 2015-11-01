// app-projects.js
(function () {

    angular.module("app-projects", ["simpleControls", "ngRoute"])
        .config(function ($routeProvider) {
            $routeProvider.when("/", {
                controller: "projectsController",
                controllerAs: "vm",
                templateUrl: "/views/projectsView.html"
            });

            $routeProvider.otherwise({
                redirectTo: "/"
            });
        });;

})();