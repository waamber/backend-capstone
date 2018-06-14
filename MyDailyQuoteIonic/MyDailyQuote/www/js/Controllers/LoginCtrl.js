angular.module('starter').controller('LoginCtrl', ["$http", "$location", "$scope", function ($http, $location, $scope) {

  $scope.login = {};


  $scope.loginUser = function () {
    $scope.error = "";
    $scope.inProgress = true;
    $http({
      method: 'POST',
      url: 'http://localhost:50987/Login',
      headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
      transformRequest: function (obj) {
        var str = [];
        for (var p in obj)
          str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
        return str.join("&");
      },
      data: { grant_type: "password", username: $scope.login.username, password: $scope.login.password }
    })
      .then(function (result) {
        sessionStorage.setItem('token', result.data.access_token);
        $http.defaults.headers.common['Authorization'] = `bearer ${result.data.access_token}`;
        authorizeToken(result.data.access_token);
        //$location.path('/tab/home');

        $scope.inProgress = false;
      }, function (error) {
        //$scope.error = error.data.error_description;
        $scope.inProgress = false;
      })
      //.then($http.get('http://localhost:50987/Login'), {
      //  headers: {
      //    "Authorization": `bearer ${result.data.access_token}`
      //  }
      //});

    var authorizeToken = function (token) {
      $http.get('http://localhost:50987/Login'), {
        headers: {
          "Authorization": `bearrer ${token}`
        }
      };
    };

  };

}]);
