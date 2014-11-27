var ListVehicleCtrl = function ($http, $scope) {
    (function getVehicles() {
        $http.get('/Home/GetVehicles')
            .success(function (data) {
                $scope.vehicles = data;
                $scope.query = {}
                $scope.queryBy = '$'
            })
            .error(function (err) {
                console.log(err.message);
            });;
    })();
}

ListVehicleCtrl.$inject = ['$http', '$scope'];