(function () {

    "use strict";

    angular.module('projectsServices', ['ngResource'])
        .factory('Project', Project);

    Project.$inject = ['$resource'];

    function Project($resource) {
        return $resource('/api/projects/:id', { id: '@id' }, {
            get: {
                method: 'GET',
                isArray: false
            },
            query: {
                method: 'GET',
                isArray: true
            },
            save: {
                url: '/api/projects/',
                method: 'POST',
                isArray: false
            },
            update: {
                url: '/api/projects/',
                method: 'PUT',
                isArray: false
            },
            getDetails: {
                url: '/api/projects/:id/details',
                method: 'GET',
                isArray: false
            },
            getLookups: {
                url: '/api/projects/getlookups',
                method: 'GET',
                isArray: true
            }
        });
    };
})();