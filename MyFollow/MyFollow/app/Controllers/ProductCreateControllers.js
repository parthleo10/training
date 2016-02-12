app.controller('productCreateController', function productCreateController($scope, $http, $location) {

    $scope.CreateProduct = function() {
        if ($scope.productName) {
            var product = {
                "ProductName": $scope.productName,
                "ProductDetails": $scope.productDetails,
                "productPrice": $scope.productPrice
        }
            $http.post('/api/ProductApi/Create', product).
                success(function(data, status, header, config) {
                    alert('product added successsfully');
                    $location.path('/');
                }).
                error(function(data, status, header, config) {
                    alert("error");
                });
        }
    };

});