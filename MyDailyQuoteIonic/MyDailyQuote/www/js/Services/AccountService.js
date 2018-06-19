angular.module('starter').service('AccountService', function ($http, $q, $rootScope) {

  this.getUserById = function (userId) {
    return $q((resolve, reject) => {
      $http.get(`http://localhost:50987/api/user/${userId}`).then(function (results) {
        resolve(results.data);
      }).catch(function (err) {
        reject("Error in AccountService.", err);
      });
    });
  }

});
