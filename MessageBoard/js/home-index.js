// home-index.js

var module = angular.module("homeIndex", ['ngRoute']);

module.config(function($routeProvider) {
    $routeProvider.when("/", {
        controller: "topicsController",
        templateUrl: "/templates/topicsView.html"
    });

    $routeProvider.otherwise({redirectTo: "/" });
});

module.controller("topicsController", function ($scope, $http) {
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/api/v1/topics?includeReplies=true")
        .then(function (result) {
            // Success fn
            $scope.dataCount = result.data.length;
            angular.copy(result.data, $scope.data);
        },
            function () {
                // Failure fn
                alert("Could not load topics");
            })
        .then(function () {
            $scope.isBusy = false;
        });
});
