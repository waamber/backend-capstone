angular.module('starter').controller('AccountCtrl', ["AccountService", "$rootScope", "$scope", "$state", "$ionicPopup", function (AccountService, $rootScope, $scope, $state, $ionicPopup) {

  var userId = $rootScope.UserId;
  $scope.user = {};

  AccountService.getUserById(userId).then(function (results) {
    $scope.user = results;
    $scope.user.UserId = userId;
  }).catch(function (err) {
    console.log("Error in getUserById().", err);
  });

  $scope.updateUser = function (user) {
    AccountService.updateUser(user).then(function (results) {
      $scope.updateConfirm();
    }).catch(function (err) {
      console.log("Error in updateUser()", err);
    });
  };

  $scope.updateConfirm = function () {
    var alertPopup = $ionicPopup.alert({
      title: 'Update Confirmation',
      template: 'Your phone number has been updated!'
    });

    alertPopup.then(function (res) {
      $state.transitionTo($state.current, null, { reload: true, inherit: true, notify: true });
    });
  };

  $scope.logout = function () {
    $state.go('login');
  };


}
]);
