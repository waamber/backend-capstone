angular.module('starter').controller('LoginCtrl', ["$http", "$scope", function ($scope, $http) {
  $scope.username = "";
  $scope.password = "";
  
  $scope.login = function () {
    $scope.error = "";
    $scope.inProgress = true;
    $http({
      method: 'POST',
      url: "/Login",
      headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
      transformRequest: function (obj) {
        var str = [];
        for (var p in obj)
          str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
        return str.join("&");
      },
      data: { grant_type: "password", username: $scope.username, password: $scope.password }
    })
      .then(function (result) {
        sessionStorage.setItem('token', result.data.access_token);
        $http.defaults.headers.common['Authorization'] = `bearer ${result.data.access_token}`;
        $location.path("/");

        $scope.inProgress = false;
      }, function (result) {
        $scope.error = result.data.error_description;
        $scope.inProgress = false;
      });
  };

}
]);
