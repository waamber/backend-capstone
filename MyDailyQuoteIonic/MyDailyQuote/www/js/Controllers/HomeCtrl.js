angular.module('starter').controller('HomeCtrl', ["$scope", "$http", "$location", "$stateParams", "HomeService", "$state", function ($scope, $http, $location, $stateParams, HomeService, $state) {

  HomeService.getShows().then(function (results) {
    $scope.shows = results;
  }).catch(function (err) {
    console.log("Error in getShows().", err);
  });

  var userId = $stateParams.id;
  var showId;

  HomeService.getSubscriptionsById(userId).then(function (results) {
    $scope.subscriptions = results;
  }).catch(function (err) {
    console.log("Error in getSubscriptionById,", err);
  });

  $scope.unsubscribe = function (showId) {
    HomeService.unsubscribeToShow(userId, showId).then(function (results) {
      //$state.go($state.current, $stateParams, { reload: true, inherit: false });
    }).catch(function (err) {
      console.log("Error in unsubscribeToShow", err);
    });
  };

}
]);
