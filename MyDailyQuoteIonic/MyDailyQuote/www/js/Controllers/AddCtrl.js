angular.module('starter').controller('AddCtrl', ["$scope", "$http", "$ionicPopup", "AddService", "$state","$rootScope", function ($scope, $http, $ionicPopup, AddService, $state, $rootScope) {

  $scope.quote = {};
 
  AddService.getShows().then(function (results) {
    $scope.shows = results;
  }).catch(function (err) {
    console.log("Error in getShows().", err);
  });

  $scope.addQuote = function () {
    AddService.addNewQuote($scope.quote).then(function () {
      $scope.submissionConfirm();
    }).catch(function (err) {
      console.log("Error in AddCtrl.", err);
    });
  };

  $scope.submissionConfirm = function () {
    var alertPopup = $ionicPopup.alert({
      title: 'Submission Confirmation',
      template: 'Congrats! Your quote has been submitted!'
    });

    alertPopup.then(function (res) {
      $state.go("tab.home");
    });
  };

}
]);
