app.controller('productDetailsController', function productDetailsController($scope, $http, $routeParams) {

    $scope.getDetailsProduct = function() {
        var productId = $routeParams.productId;
        $http.get('/api/ProductApi/' + productId + '/Details').
            success(function(data) {
                $scope.productName = data.productName;
                $scope.productDetails = data.productDetails;
                $scope.productPrice = data.productPrice;
            }).
            error(function(data) {
                alert("error");
            });
        
    };

});