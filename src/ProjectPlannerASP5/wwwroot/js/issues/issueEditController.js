//issueEditController.js
(function () {

    angular.module('app')
        .controller('issueEditController', issueEditController);

    issueEditController.$inject = ['$scope', '$location', '$routeParams',
        'Issue'];

    function issueEditController($scope, $location, $routeParams, Issue) {
        if ($routeParams.id > 0 && $routeParams.projectCode) {
            $scope.issue = Issue.get({ id: $routeParams.id, projectCode: $routeParams.projectCode });
        } else {
            $scope.issue = new Issue();
            $scope.issue.id = 0;
            $scope.issue.createTimeStamp = new Date();
            $scope.issue.lastUpdateTimeStamp = new Date();
        }

        $scope.projectCode = $routeParams.projectCode;

        $scope.saveIssue = function() {
            if ($scope.issue.id === 0) {
                $scope.issue.$save({ projectCode: $scope.projectCode }).then(function() {
                    $scope.goToIssuesList();
                });
            } else {
                $scope.issue.$updateClass({ projectCode: $scope.project }).then(function() {
                    $scope.goToIssuesList();
                });
            }
        };

        $scope.cancelEdit = function() {
            $scope.goToIssuesList();
        };

        $scope.goToIssuesList = function() {
            $location.path('/Issues/' + $scope.projectCode);
        };
    };
})();