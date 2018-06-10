angular.module('starter').controller('AddCtrl', ["$scope", "$http", "$location", "AddService", function ($scope, $http, $location, AddService) {

  AddService.getShows().then(function (results) {
    $scope.shows = results;
  }).catch(function (err) {
    console.log("Error in getShows().", err);
  });

  $scope.addNewQuote = function () {
    $scope.quote.ShowId = $scope.shows.ShowId;
    AddService.addNewQuote($scope.quote).then(function () {
      console.log($scope.quote);
      navToHome();
    }).catch(function (err) {
      console.log("Error in AddCtrl.", err);
    });
  };

  var navToHome = function () {
    $location.path('/home');
  };

}
]);
