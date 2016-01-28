var app = angular.module('myApp', ['ngResource', 'ngRoute']);

app.config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
          when('/', {
              templateUrl: '/app/Template/Index.html',
              controller: 'productController'
          })
          .when('/Create', {
              templateUrl: '/app/Template/Create.html',
              controller: 'productController'
          })
          .when('/Edit', {
              templateUrl: '/app/Template/Edit.html',
              controller: 'productController'
          })
          .when('/Details', {
              templateUrl: '/app/Template/Details.html',
              controller: 'productController'
          })
          .when('/Delete', {
              templateUrl: '/app/Template/Delete.html',
              controller: 'productController'
          });
  }]);
 


