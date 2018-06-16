angular.module('starter').service('AuthService', function ($http, $q, $rootScope) {

  var _authToken = null;
  var _user = null;

  this.getUser = function () {
    return _user;
  };

  this.getAuthToken = function () {
    return _authToken;
  };

  this.setUser = function (user) {
    _user = user;
  };

  this.setAuthToken = function (authToken) {
    _authToken = authToken;
  };



});
