app.controller('editProductController', function editProductController($scope) {
    $scope.resetProduct = {};

    $scope.postCreateProduct = function (product, newProductForm) {
        if (newProductForm.$valid) {
            alert('product ' + product.name + ' ' + product.details + ' ' + product.price + ' saved!');
        }
    };
    $scope.reset = function() {
        $scope.product = angular.copy($scope.resetProduct);
    };
    
});
