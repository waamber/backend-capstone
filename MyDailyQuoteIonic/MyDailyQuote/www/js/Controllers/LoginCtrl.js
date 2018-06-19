angular.module('starter').controller('LoginCtrl', ["$http", "$location", "$q", "$scope", "$rootScope", "LoginService","$state", function ($http, $location, $q, $scope, $rootScope, LoginService,$state) {

  $scope.user = {};

  $scope.login = function () {
    LoginService.getUser($scope.user.password).then(function (results) {
      var user = results.data;
      $rootScope.UserId = user.UserId;
      $state.go("tab.home",{id : user.UserId});
  });
  };


}]);
