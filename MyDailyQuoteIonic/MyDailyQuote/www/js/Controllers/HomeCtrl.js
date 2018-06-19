angular.module('starter').controller('HomeCtrl', ["$scope", "$http", "$location", "$rootScope", "HomeService", "$state", function ($scope, $http, $location, $rootScope, HomeService, $state) {

  var userId = $rootScope.UserId;

  HomeService.getShows().then(function (results) {
    $scope.shows = results;
  }).catch(function (err) {
    console.log("Error in getShows().", err);
  });

  HomeService.getSubscriptionsById(userId).then(function (results) {
    $scope.subscriptions = results;
  }).catch(function (err) {
    console.log("Error in getSubscriptionById,", err);
  });

  $scope.unsubscribe = function (showId) {
    HomeService.unsubscribeToShow(userId, showId).then(function (results) {
      $state.transitionTo($state.current, null, { reload: true, inherit: false, notify: true });
    }).catch(function (err) {
      console.log("Error in unsubscribeToShow", err);
    });
  };

  $scope.subscribe = function (showId) {
    var id = parseInt(userId, 10);
    HomeService.subscribeToShow(id, showId).then(function (results) {
      $state.transitionTo($state.current, null, { reload: true, inherit: false, notify: true });
    }).catch(function (err) {
      console.log("Error in subscribe in HomeCtrl.", err);
    });
  };

}
]);
