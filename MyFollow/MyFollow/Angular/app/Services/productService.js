app.factory('productService', function($http, $q) {
    return {
        getProduct: function () {
            var deferred = $q.defer();
            $http({
                url: "/Product/Create",
                method: "GET"
                })
                .success(function(data, status, header, config) {
                    console.log(data);
                    deferred.resolve(data);
                }).
                error(function(data, status, header, config) {
                    console.log(status);
                    deferred.reject(status);
                });
            return deferred.promise;
        }
    };
});