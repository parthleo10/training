var app = angular.module('myApp', ['ngResource', 'ngRoute']);

app.config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
          when('/', {
              templateUrl: '/app/Template/Index.html',
              controller: 'productIndexController'
      });
      $routeProvider.when('/Create', {
          templateUrl: '/app/Template/Create.html',
          controller: 'productCreateController'
      });
      $routeProvider.when('/Update/:productId', {
          templateUrl: '/app/Template/Edit.html',
          controller: 'productEditController'
      });
      $routeProvider.when('/Details/:productId', {
          templateUrl: '/app/Template/Details.html',
          controller: 'productDetailsController'
      });
      $routeProvider.when('/Delete/:productId', {
              templateUrl: '/app/Template/Delete.html',
              controller: 'productDeleteController'
      });
      $routeProvider.otherwise({
          redirectTo: '/'
      });
  }]);
 


