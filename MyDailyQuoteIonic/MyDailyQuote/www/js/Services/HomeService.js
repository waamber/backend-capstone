angular.module('starter').service('HomeService',  function ($http, $q, $rootScope, AuthService) {

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
        console.log(results.data);
      }).catch(function (err) {
        reject("Error in HomeService.", err);
      });
    });
  };

});
