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

    $rootScope.isLoggedIn = function () { return !!sessionStorage.getItem("token") };

    $rootScope.$on("$routeChangeStart", function (event, currRoute) {
      var anonymousPage = false;
      var originalPath = currRoute.originalPath;

      if (originalPath) {
        anonymousPage = originalPath.indexOf("/login") !== -1;
      }

      if (!anonymousPage && !$rootScope.isLoggedIn()) {
        event.preventDefault();
        $location.path("/tab/home");
      }
    });

    var token = sessionStorage.getItem("token");

    if (token)
      $http.defaults.headers.common["Authorization"] = `bearer ${token}`;
  }
  ])
  .config(function ($stateProvider, $urlRouterProvider) {
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
        views: {
          'tab-home': {
            templateUrl: 'templates/tab-home.html',
            controller: 'HomeCtrl'
          }
        }
      })
      .state('tab.add', {
        url: '/add',
        views: {
          'tab-add': {
            templateUrl: 'templates/tab-add.html',
            controller: 'AddCtrl'
          }
        }
      })
      .state('tab.account', {
        url: '/account',
        views: {
          'tab-account': {
            templateUrl: 'templates/tab-account.html',
            controller: 'AccountCtrl'
          }
        }
      });

    $urlRouterProvider.otherwise('/login');

  });
