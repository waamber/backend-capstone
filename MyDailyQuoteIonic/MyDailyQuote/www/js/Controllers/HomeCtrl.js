angular.module('starter').controller('HomeCtrl', ["$scope", "$http", "$location", "$stateParams", "HomeService", function ($scope, $http, $location, $stateParams, HomeService) {

  HomeService.getShows().then(function (results) {
    $scope.shows = results;
  }).catch(function (err) {
    console.log("Error in getShows().", err);
  });

  var userId = $stateParams.id;

  HomeService.getSubscriptionsById(userId).then(function (results) {
    $scope.subscriptions = results;
  }).catch(function (err) {
    console.log("Error in getSubscriptionById,", err);
  });

}
]);
