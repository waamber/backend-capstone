angular.module('starter').service('AccountService', function ($http, $q) {

  this.getUserById = function (userId) {
    return $q((resolve, reject) => {
      $http.get(`http://localhost:50987/api/user/${userId}`).then(function (results) {
        resolve(results.data);
      }).catch(function (err) {
        reject("Error in AccountService.", err);
      });
    });
  }

  this.updateUser = function (user) {
    return $q((resolve, reject) => {
      $http.put(`http://localhost:50987/api/user/update/${user.UserId}`, user).then(function (results){
        resolve(results);
      }).catch(function (err) {
        reject("Error in AccountService.", err);
      });
    });
  };

});
