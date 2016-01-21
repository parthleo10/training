app.controller('productController', function productController($scope) {
    $scope.product = {};
   // -----------------------------------------------------------------------------
        
//-----------------------------------------------------------------------------
    $scope.ProductsIndex = [
    {
        name: 'Adizero F50',
        details : 'football product!',
        price : '$19'
        
    }
    ];

    //----------------------------------------------------------------------
    $scope.resetProduct = {};

    //----------------------------------------------------------------------

    $scope.postCreateProduct = function (product, newProductForm) {
        if (newProductForm.$valid) {
            
            alert('product ' + product.name + ' ' + product.details + ' ' + product.price + ' saved!');
        }
    };

    //----------------------------------------------------------------------

    $scope.reset = function () {
        $scope.product = angular.copy($scope.resetProduct);
    };

    //----------------------------------------------------------------------

});
