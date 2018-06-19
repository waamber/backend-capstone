angular.module('starter').controller('AccountCtrl', ["AccountService", "$rootScope", "$scope", function (AccountService, $rootScope, $scope) {

  var userId = $rootScope.UserId;

  AccountService.getUserById(userId).then(function (results) {
    $scope.user = results;
  }).catch(function (err) {
    console.log("Error in AccountCtrl.", err);
  });


}
]);
