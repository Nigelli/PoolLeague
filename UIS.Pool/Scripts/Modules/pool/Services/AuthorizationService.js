var pool;
(function (pool) {
    var Services;
    (function (Services) {
        "use strict";
        var AuthorizationService = /** @class */ (function () {
            function AuthorizationService($http) {
                this.isAuthorized = function () {
                    $http.get("/Account/IsUserAuthenticated")
                        .then(function (result) {
                        return result.data;
                    });
                };
            }
            AuthorizationService.$inject = ['$http'];
            return AuthorizationService;
        }());
        Services.AuthorizationService = AuthorizationService;
    })(Services = pool.Services || (pool.Services = {}));
})(pool || (pool = {}));
