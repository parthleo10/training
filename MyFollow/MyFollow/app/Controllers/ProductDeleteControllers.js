app.controller('productDeleteController', function productDeleteController($scope,$http,$location,$routeParams) {

    $scope.getDeleteProduct = function () {
        var productId = $routeParams.productId;
        $http.get('/api/ProductApi/' + productId).
                success(function (data) {
                    $scope.productName = data.productName;
                    $scope.productDetails = data.productDetails;
                    $scope.productPrice = data.productPrice;
                }).
                error(function (data) {
                    alert("error");

                });
    };

    $scope.DeleteProduct = function() {
        var productId = $routeParams.productId;
      $http.delete('/api/ProductApi/' + productId + '/Delete').
                success(function (data, status, header, config) {
                    alert('product deleted successsfully');
                    $location.path('/');
                }).
                error(function (data, status, header, config) {
                    alert("error");
                });
       
    };


});