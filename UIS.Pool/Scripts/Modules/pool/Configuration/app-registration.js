var pool;
(function (pool) {
    var core;
    (function (core) {
        "use strict";
        /*
            Application Registration - This file handle the file registration for AngularJS
        
            You can edit this file to override registered classes for the angular app.
        */
        //#region ModuleRegistration
        angular.module('pool.Core', [
            'ngAnimate',
            'ngCookies',
            'ngSanitize',
            'ngRoute',
        ]);
        angular.module('pool.Core')
            .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
                $routeProvider
                    .when("/Leagues", {
                    templateUrl: "/NgTemplates?ViewName=leagues",
                    controller: "ViewLeaguesController",
                    controllerAs: "vm",
                    caseInsensitiveMatch: true
                })
                    .when("/Manage-Leagues", {
                    templateUrl: "/NgTemplates?ViewName=manage-leagues",
                    controller: "ManageLeaguesController",
                    controllerAs: "vm",
                    caseInsensitiveMatch: true,
                    resolve: {}
                })
                    .otherwise({
                    templateUrl: "/NgTemplates?ViewName=leagues",
                    controller: "ViewLeaguesController",
                    controllerAs: "vm",
                });
                $locationProvider.html5Mode({
                    enabled: true,
                    requireBase: false
                });
            }]);
        angular.module('pool.Core').run(function ($http) {
            $http.defaults.headers.common['X-XSRF-Token'] = angular.element('input[name="__RequestVerificationToken"]').attr('value');
        });
        //#endregion
        //#region ControllerRegistration
        var ViewLeaguesController = pool.Controllers.ViewLeaguesController;
        var ManageLeaguesController = pool.Controllers.ManageLeaguesController;
        angular.module("pool.Core")
            .controller("ViewLeaguesController", ViewLeaguesController);
        angular.module("pool.Core")
            .controller("ManageLeaguesController", ManageLeaguesController);
        //#endregion
        //#region ServicesRegistration
        var AuthorizationService = pool.Services.AuthorizationService;
        var LeagueService = pool.Services.LeagueService;
        var SeasonService = pool.Services.SeasonService;
        var MatchService = pool.Services.MatchService;
        var PlayerService = pool.Services.PlayerService;
        angular.module('pool.Core')
            .service('AthorizationService', AuthorizationService);
        angular.module('pool.Core')
            .service('LeagueService', LeagueService);
        angular.module('pool.Core')
            .service('SeasonService', SeasonService);
        angular.module('pool.Core')
            .service('MatchService', MatchService);
        angular.module('pool.Core')
            .service('PlayerService', PlayerService);
        //#endregion
    })(core = pool.core || (pool.core = {}));
})(pool || (pool = {}));
