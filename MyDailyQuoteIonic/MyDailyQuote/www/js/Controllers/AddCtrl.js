angular.module('starter').controller('AddCtrl', ["$scope", "$http", "$location", "AddService", function ($scope, $http, $location, AddService) {

  $scope.quote = {};

  AddService.getShows().then(function (results) {
    $scope.shows = results;
  }).catch(function (err) {
    console.log("Error in getShows().", err);
  });

  $scope.addQuote = function () {
    AddService.addNewQuote($scope.quote).then(function () {
      $location.path('/tab/home');
    }).catch(function (err) {
      console.log("Error in AddCtrl.", err);
    });
  };

}
]);
