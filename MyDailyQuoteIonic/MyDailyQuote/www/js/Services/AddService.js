angular.module('starter').service('AddService', function ($http, $q, $rootScope) {

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

  this.addNewQuote = function (quote) {
    return $q((resolve, reject) => {
      $http.post(`http://localhost:50987/api/quotes/add`).then(function (results) {
        resolve(results);
      }).catch(function (err) {
        reject("Error in AddService.js", err);
      });
    });
  };

});
