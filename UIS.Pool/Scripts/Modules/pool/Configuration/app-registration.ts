namespace pool.core {
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
        //'ui.bootstrap',
        //'vcRecaptcha',
        //'ngFileUpload'
    ]);

    angular.module('pool.Core')
        .config(['$routeProvider', '$locationProvider', ($routeProvider, $locationProvider) => {
            $routeProvider
                .when("/Leagues", {
                    templateUrl: "/NgTemplates?ViewName=leagues",
                    controller: "ViewLeaguesController",
                    controllerAs: "vm",
                    caseInsensitiveMatch: true
                })
                .when("/Manage-Leagues",
                {
                    templateUrl: "/NgTemplates?ViewName=manage-leagues",
                    controller: "ManageLeaguesController",
                    controllerAs: "vm",
                    caseInsensitiveMatch: true,
                    resolve: {
                    }
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

    angular.module('pool.Core').run($http => {
        $http.defaults.headers.common['X-XSRF-Token'] = angular.element('input[name="__RequestVerificationToken"]').attr('value');
    });

//#endregion

//#region ControllerRegistration

    import ViewLeaguesController = pool.Controllers.ViewLeaguesController;
    import ManageLeaguesController = pool.Controllers.ManageLeaguesController;

    angular.module("pool.Core")
        .controller("ViewLeaguesController", ViewLeaguesController);

    angular.module("pool.Core")
        .controller("ManageLeaguesController", ManageLeaguesController);



//#endregion

//#region ServicesRegistration

    import AuthorizationService = pool.Services.AuthorizationService;
    import LeagueService = pool.Services.LeagueService;
    import SeasonService = pool.Services.SeasonService;
    import MatchService = pool.Services.MatchService;
    
    angular.module('pool.Core')
        .service('AthorizationService', AuthorizationService);

    angular.module('pool.Core')
        .service('LeagueService', LeagueService);

    angular.module('pool.Core')
        .service('SeasonService', SeasonService);

    angular.module('pool.Core')
        .service('MatchService', MatchService);

//#endregion
}