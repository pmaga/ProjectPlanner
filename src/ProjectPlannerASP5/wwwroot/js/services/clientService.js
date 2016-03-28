//clientService.js
(function () {
    "use strict";

    angular.module('appServices', ['ngResource'])
        .factory('Client', Client);

    Client.$inject = ['$resource'];

    function Client($resource) {
        return $resource('/api/clients/:id', { id: '@id' }, {
            getLookups: {
                url: '/api/clients/getLookups',
                method: 'GET',
                isArray: true
            }   
        });
    };
})();