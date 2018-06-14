angular.module('starter').controller('HomeCtrl', ["$scope", "$http", "$location", "$routeParams", "HomeService", function ($scope, $http, $location, $routeParams, HomeService) {

  var userId = User.Identity.GetUserId();

  HomeService.getShows().then(function (results) {
    $scope.shows = results;
  }).catch(function (err) {
    console.log("Error in getShows().", err);
  });

  HomeService.getSubscriptionsById(u$routParams.id).then(function (results) {
    $scope.subscriptions = results;
  }).catch(function (err) {
    console.log("Error in getSubscriptionById,", err);
  });



}
]);
