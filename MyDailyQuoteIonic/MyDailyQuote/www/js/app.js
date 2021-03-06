angular.module('starter', ['ionic'])
  .run(["$rootScope", "$http", "$location", "$ionicPlatform", function ($rootScope, $http, $location, $ionicPlatform) {
    $ionicPlatform.ready(function () {
      if (window.cordova && window.cordova.plugins && window.cordova.plugins.Keyboard) {
        cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
        cordova.plugins.Keyboard.disableScroll(true);
      }
      if (window.StatusBar) {
        StatusBar.styleDefault();
      }
    });
  }
  ])
  .config(function ($stateProvider, $urlRouterProvider, $ionicConfigProvider) {
    $stateProvider
      .state('login', {
        url: '/login',
        templateUrl: 'templates/login.html',
        controller: 'LoginCtrl'
      })
      .state('tab', {
        url: '/tab',
        abstract: true,
        templateUrl: 'templates/tabs.html'
      })
      .state('tab.home', {
        url: '/home',
        cache: false,
        views: {
          'tab-home': {
            templateUrl: 'templates/tab-home.html',
            controller: 'HomeCtrl'
          }
        }
      })
      .state('tab.add', {
        url: '/add',
        cache: false,
        views: {
          'tab-add': {
            templateUrl: 'templates/tab-add.html',
            controller: 'AddCtrl'
          }
        }
      })
      .state('tab.account', {
        url: '/account',
        cache: false,
        views: {
          'tab-account': {
            templateUrl: 'templates/tab-account.html',
            controller: 'AccountCtrl'
          }
        }
      });

    $urlRouterProvider.otherwise('/login');

  });
