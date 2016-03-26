(function () {
    'use strict';

    angular.module('issueServices', ['ngResource'])
        .factory('Issue', Issue);

    Issue.$inject = ['$resource'];

    function Issue($resource) {
        return $resource('/api/projects/:projectCode/issues', { projectCode: '@projectCode' }, {
            get: {
                url: '/api/issues/:id',
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
                url: '/api/issues',
                method: 'PUT',
                isArray: false
            }
        });
    };
})();