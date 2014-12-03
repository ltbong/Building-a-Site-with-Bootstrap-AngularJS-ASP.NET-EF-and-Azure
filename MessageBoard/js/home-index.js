// home-index.js

var app = angular.module("myapp", []);

app.controller("homeIndexController", function ($scope, $http) {
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