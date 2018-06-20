angular.module('starter').controller('HomeCtrl', ["$scope", "$http", "$rootScope", "HomeService", "$state", function ($scope, $http, $rootScope, HomeService, $state) {

  var userId = $rootScope.UserId;

  HomeService.getSubscriptionsById(userId).then(function (results) {
    $scope.subscriptions = results;
  }).catch(function (err) {
    console.log("Error in getSubscriptionById,", err);
  }).then(function () {
    HomeService.getShows().then(function (results) {
      var subscribedShows = $scope.subscriptions.map(function (sub) {return sub.ShowId})
      $scope.shows = results.filter(function (show) { return subscribedShows.indexOf(show.ShowId) == -1 });
    }).catch(function (err) {
      console.log("Error in getShows().", err);
    });
  })

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
