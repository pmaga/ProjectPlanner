//clientService.js
(function () {
    "use strict";

    angular.module('clientService', ['ngResource'])
        .factory('Client', Client);

    Client.$inject = ['$resource'];

    function Client($resource) {
        return $resource('/api/clients/:id', { id: '@id' }, {
            getLookups: {
                url: '/api/clients/getLookups',
                method: 'GET',
                isArray: true
            },
            getDetails: {
                url: '/api/clients/:id/details',
                method: 'GET',
                isArray: false
            },
            update: {
                url: "/api/clients/",
                method: 'PUT',
                isArray: false
            }
        });
    };
})();