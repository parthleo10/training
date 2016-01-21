/// <reference path="D:\parth2015\training\MyFollow\MyFollow\Views/Product/Create.cshtml" />
var app = angular.module('myApp', ['ngResource', 'ngRoute'])
.config(function($routeProvider) {
    $routeProvider
        .when('/Create',
        {
            templateUrl: 'hello',
            controller: 'productController'
        });
    });


