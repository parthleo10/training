app.controller('productEditController', function productEditController($scope, $http, $location, $routeParams) {

    $scope.getEditProduct = function () {
        var productId = $routeParams.productId;
        $http.get('/api/ProductApi/' + productId).
                success(function(data) {
                $scope.productName = data.productName;
                $scope.productDetails = data.productDetails;
                $scope.productPrice = data.productPrice;
            }).
                error(function(data) {
                    alert("error");

                });
  };
      $scope.EditProduct = function () {
        var productId = $routeParams.productId;
        if ($scope.productName) {
            var product = {
                "ProductId" : productId, 
                "ProductName": $scope.productName,
                "ProductDetails": $scope.productDetails,
                "ProductPrice": $scope.productPrice
            }
            $http.put('/api/ProductApi/' + productId + '/Update', product).
                success(function (data, status, header, config) {
                    alert('product updated successsfully');
                    $location.path('/');
                }).
                error(function (data, status, header, config) {
                    alert("error");
                });
            }
    };

});