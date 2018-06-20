angular.module('starter').controller('LoginCtrl', ["$http", "$location", "$q", "$scope", "$rootScope", "LoginService","$state", "$ionicPopup", function ($http, $location, $q, $scope, $rootScope, LoginService, $state, $ionicPopup) {

  $scope.user = {};

  $scope.login = function () {
    LoginService.getUser($scope.user.password).then(function (results) {
      var user = results.data;
      $rootScope.UserId = user.UserId;
      $state.go("tab.home",{id : user.UserId});
  });
  };

  $scope.signUpUser = function () {
    LoginService.createNewUser($scope.user).then(function (results) {
      LoginService.getUser($scope.user.password).then(function (results) {
        var user = results.data;
        $rootScope.UserId = user.UserId;
        $state.go("tab.home", { id: user.UserId });
      });
    });
  };

}]);
