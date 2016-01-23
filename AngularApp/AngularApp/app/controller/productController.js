app.controller('productController', function($scope, productService) {
    $scope.message = "parth is a boy";

    $scope.displayMsg = function () {
        productService.displayMessage();
    }
});