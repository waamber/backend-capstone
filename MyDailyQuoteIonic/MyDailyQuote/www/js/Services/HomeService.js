angular.module('starter').service('HomeService',  function ($http, $q, $rootScope) {

  this.getShows = function () {
    var showList = [];
    return $q((resolve, reject) => {
      $http.get(`http://localhost:50987/api/shows`).then(function (results) {
        var shows = results.data;
        Object.keys(shows).forEach(function (key) {
          showList.push(shows[key]);
        });
        resolve(showList);
      }).catch(function (err) {
        reject("Error in HomeService.", err);
      });
    });
  };

  this.getSubscriptionsById = function (userId) {
    return $q((resolve, reject) => {
      $http.get(`http://localhost:50987/api/subscriptions/${userId}`).then(function (results) {
        resolve(results.data);
      }).catch(function (err) {
        reject("Error in HomeService.", err);
      });
    });
  };

  this.unsubscribeToShow = function (userId, showId) {
    return $q((resolve, reject) => {
      $http.delete(`http://localhost:50987/api/subscriptions/unsubscribe/${userId}/${showId}`).then(function (results) {
        resolve(results);
      }).catch(function (err) {
        reject("Error in HomeService.", err);
      });
    });
  };

});
