var app = angular.module('myApp', ['ngResource', 'ngRoute']);

app.config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
          when('/', {
              templateUrl: '/app/Template/Index.html',
              controller: 'productController'
          });
      $routeProvider.when('/Create', {
          templateUrl: '/app/Template/Create.html',
          controller: 'productController'
      });
      $routeProvider.when('/Edit', {
          templateUrl: '/app/Template/Edit.html',
          controller: 'productController'
      });
      $routeProvider.when('/Details', {
          templateUrl: '/app/Template/Details.html',
          controller: 'productController'
      });
      $routeProvider.when('/Delete', {
              templateUrl: '/app/Template/Delete.html',
              controller: 'productController'
          });
  }]);
 


