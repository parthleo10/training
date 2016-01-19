app.controller('productController', function productController($scope, productService) {
        $scope.getCreateProduct = function() {

            productService.getProduct().then(
                function(product) {
                     $scope.product = product;
                },
                function(statusCode) {
                     console.log(statusCode);
                }
               );
            }

    $scope.ProductsIndex = [
    {
        name: 'parth',
        details : 'best product!',
        price : '$10'

    }
        ];
}
);
