(function () {
    'use strict';

    angular.module('issueServices', ['ngResource'])
        .factory('Issue', Issue);

    Issue.$inject = ['$resource'];

    function Issue($resource) {
        return $resource('/api/projects/:projectCode/issues/:id', { projectCode: '@projectCode', id: '@id' }, {
            get: {
                method: 'GET',
                isArray: false
            },
            query: {
                method: 'GET',
                isArray: true
            },
            save: {
                url: '/api/projects/:projectCode/issues',
                method: 'POST',
                isArray: false
            },
            update: {
                url: '/api/projects/:projectCode/issues',
                method: 'PUT',
                isArray: false
            },
            remove: {
                url: '/api/projects/:projectCode/issues/:id',
                method: 'DELETE',
                isArray: false
            }
        });
    };
})();