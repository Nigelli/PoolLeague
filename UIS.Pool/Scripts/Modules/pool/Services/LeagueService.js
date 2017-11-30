var pool;
(function (pool) {
    var Services;
    (function (Services) {
        "use strict";
        var LeagueService = /** @class */ (function () {
            function LeagueService($http, $q) {
                this.GetLeaguesBySeason = function (id) {
                    return $http.post("/data/leagues/get?Id=" + id);
                };
                this.CreateLeague = function (league) { return $http.post("/data/leagues/add", league); };
                this.AddPlayer = function (playerId, leagueId) { return $http.post("/data/leagues/addPlayer?PlayerId=" + playerId + "&LeagueId=" + leagueId); };
            }
            LeagueService.$inject = ['$http', '$q'];
            return LeagueService;
        }());
        Services.LeagueService = LeagueService;
    })(Services = pool.Services || (pool.Services = {}));
})(pool || (pool = {}));
//# sourceMappingURL=LeagueService.js.map