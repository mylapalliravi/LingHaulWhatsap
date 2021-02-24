/// <reference path="angular.min.js" />


var app = angular.module('Homeapp', []);

app.controller('HomeController', function ($scope, $http) {

    $http.get('/Home/Get_employee').then(function (d) {

        $scope.regdata = d.data;
        $scope.rowlimit = 5;

    }, function (error) {

        alert('failed');

    });

});