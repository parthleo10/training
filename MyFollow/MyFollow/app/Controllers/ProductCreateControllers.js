app.controller('productCreateController', function productCreateController($scope, $http, $location) {

    $scope.CreateProduct = function() {
        if ($scope.Name) {
            var product = {
                "ProductName": $scope.Name,
                "ProductDetails": $scope.Details,
                "ProductPrice": $scope.Price
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