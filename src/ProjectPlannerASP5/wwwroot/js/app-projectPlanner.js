// app-projects.js
(function () {

    angular.module("projectsModule", []);
    angular.module("issuesModule", []);

    angular.module("app-projectPlanner", ["projectsModule", "issuesModule",
        "simpleControls", "ngRoute"]);
})();