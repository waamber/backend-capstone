angular.module('starter').service('LoginService', function ($http, $q, $rootScope) {

  this.getUser = function (password) {
    return $q((resolve, reject) => {
      $http.get(`http://localhost:50987/api/login/${password}`).then(function (results) {
        resolve(results);
      }).catch(function (err) {
        reject("Error in getUser in LoginService", err);
      });
    });
  };


  //this.createNewUser = function (user) {
  //  return $q((resolve, reject) => {
  //    $http.post(``)
  //  })
  //}



});
