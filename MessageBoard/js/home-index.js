// home-index.js
var module = angular.module("homeIndex", ['ngRoute']);

module.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "topicsController",
        templateUrl: "/templates/topicsView.html"
    });

    $routeProvider.when("/newmessage", {
        controller: "newTopicController",
        templateUrl: "/templates/newTopicView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/" });
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

module.controller("newTopicController", function ($scope, $http, $window) {
    $scope.newTopic = {};

    $scope.save = function () {
        $http.post("/api/v1/topics", $scope.newTopic)
            .then(function (result) {
                // success
                var newTopic = result.data;
                // TODO merge with existing list of topics.
                $window.location = "#/";
            }, 
            function () {
                // falure
                alert("Cannot save the new topic... Sorry!");
            }
            );
    };
});
