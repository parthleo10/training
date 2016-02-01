app.controller('productController', function productController($scope, $http, $location) {
    $scope.product = {};

    //-----------------------------------------------------------------------------
    //posting values to db
    //----------------------------------------------------------------------------
    $scope.CreateProduct = function () {
        if ($scope.Name) {
            var product = {
                "ProductName": $scope.Name,
                "ProductDetails": $scope.Details,
                "ProductPrice": $scope.Price
            }
            $http.post('https://localhost:44300/api/ProductApi/Create', product).
                success(function(data, status, header, config) {
                    alert('product added successsfully');
                    $location.path('/');
                }).
                error(function(data, status, header, config) {
                    alert("error");
                });
        }
    };

    //-------------------------------------------------------------------------------
    //getting values from db
//----------------------------------------------------------------------------
    $scope.getAdminProducts = function () {
       $http.get('https://localhost:44300/api/ProductApi').
                success(function (data, status, header, config) {
               $scope.products = data;
           }).
                error(function (data, status, header, config) {
                    alert("error");
                });
    };

//-----------------------------------------------------------------------------
    /*$scope.products = [
    {
        name: 'Adizero F50',
        details : 'football product!',
        price : '$19'
        
    }];*/

    //----------------------------------------------------------------------

    

    //----------------------------------------------------------------------
    

    //----------------------------------------------------------------------

    $scope.reset = function () {
        $scope.product = angular.copy($scope.resetProduct);
    };

    //----------------------------------------------------------------------

});
