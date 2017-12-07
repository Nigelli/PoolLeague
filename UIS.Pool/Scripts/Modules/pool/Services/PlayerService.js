var pool;
(function (pool) {
    var Services;
    (function (Services) {
        "use strict";
        var PlayerService = /** @class */ (function () {
            function PlayerService($http, $q) {
                this.GetPlayers = function () { return $http.get("/data/players/get"); };
                this.AddPlayer = function (name) { return $http.post("/data/players/add?name=" + name); };
            }
            PlayerService.$inject = ['$http', '$q'];
            return PlayerService;
        }());
        Services.PlayerService = PlayerService;
    })(Services = pool.Services || (pool.Services = {}));
})(pool || (pool = {}));
//# sourceMappingURL=PlayerService.js.map