app.controller('productIndexController', function productIndexController($scope, $http, $location) {
    $scope.product = {};

    //-----------------------------------------------------------------------------
    //-------------------------------------------------------------------------------
    //getting values from db
//----------------------------------------------------------------------------
    $scope.getOwnerProducts = function () {
       $http.get('/api/ProductApi').
                success(function (data, status, header, config) {
               $scope.products = data;
           }).
                error(function (data, status, header, config) {
                    alert("error");
                });
    };

//-----------------------------------------------------------------------------
   
   $scope.reset = function () {
        $scope.product = angular.copy($scope.resetProduct);
    };

    //----------------------------------------------------------------------

});
