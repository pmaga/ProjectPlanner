(function () {

    "use strict";

    angular.module('projectsServices', ['ngResource'])
        .factory('Project', Project);

    Project.$inject = ['$resource'];

    function Project($resource) {
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
            update: {
                method: 'PUT',
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