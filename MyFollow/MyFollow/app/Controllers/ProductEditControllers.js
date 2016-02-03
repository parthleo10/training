app.controller('productEditController', function productEditController($scope, $http, $location) {

    /*$scope.getEditProduct = function() {

        $location.path("/Edit");


    };*/


    $scope.CreateProduct = function () {
        if ($scope.Name) {
            var product = {
                "ProductName": $scope.Name,
                "ProductDetails": $scope.Details,
                "ProductPrice": $scope.Price
            }
            $http.put('/api/ProductApi/' + id + '/Update' , product).
                success(function (data, status, header, config) {
                    alert('<h2>product updated successsfully</h2>');
                    $location.path('/');
                }).
                error(function (data, status, header, config) {
                    alert("error");
                });
        }
    };

});