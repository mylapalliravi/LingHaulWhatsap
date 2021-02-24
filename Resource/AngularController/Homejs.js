var app = angular.module("Homeapp", ['ui.bootstrap']);

app.controller("HomeController", function ($scope, $http) {

    $scope.maxsize = 5;
    $scope.totalcount = 0;
    $scope.pageIndex = 1;
    $scope.pageSize = 5;

    $scope.registerlist = function () {
        $http.get("/Home/Get_employee?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.rprt_usrs = response.data.rprt_usrs;
            $scope.totalcount = response.data.totalcount;
        }, function (error) {
            alert('failed');
        });
    }

    $scope.registerlist();

    $scope.pagechanged = function () {
        $scope.registerlist();
    }

    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.registerlist();
    }


    $scope.Update_password = function () {

    }



});