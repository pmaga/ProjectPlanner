(function () {

    "use strict";

    angular.module('projectsServices', ['ngResource'])
        .factory('projectsService', ProjectsService);

    ProjectsService.$inject = ['$resource'];

    function ProjectsService($resource) {
        return $resource('/api/projects/:id', {}, {
            get: {
                method: 'GET',
                isArray: false
            },
            query: {
                method: 'GET',
                isArray: true
            },
            save: {
                method: 'POST',
                isArray: false
            },
            getDetails: {
                url: '/api/projects/:id/details',
                method: 'GET',
                isArray: false
            }
        });
    };
})();