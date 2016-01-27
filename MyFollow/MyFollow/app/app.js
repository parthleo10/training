/// <reference path="D:\parth2015\training\MyFollow\MyFollow\Views/Product/Create.cshtml" />
var app = angular.module('myApp', ['ngResource', 'ngRoute']);


app.config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
          when('/Create', {
              templateUrl: 'app/Template/index.html',
              controller: 'productController'
          });

  }]);
 


