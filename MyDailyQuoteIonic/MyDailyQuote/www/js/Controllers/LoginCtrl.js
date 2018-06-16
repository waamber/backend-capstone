angular.module('starter').controller('LoginCtrl', ["$http", "$location", "$q", "$scope", "LoginService","$state", function ($http, $location, $q, $scope, LoginService,$state) {

  $scope.user = {};

  $scope.login = function () {
    LoginService.getUser($scope.user.password).then(function (results) {
      var user = results.data;
      $state.go("tab.home",{id : user.UserId});
  });
  };


}]);
