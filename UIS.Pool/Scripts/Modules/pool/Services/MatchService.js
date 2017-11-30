var pool;
(function (pool) {
    var Services;
    (function (Services) {
        "use strict";
        var MatchService = /** @class */ (function () {
            function MatchService($http, $q) {
                this.GetMatchesByLeague = function (id) {
                    return $http.post("/data/matches/get?Id=" + id);
                };
                this.UpdateMatch = function (match) {
                    return $http.post("/data/matches/add", match);
                };
                this.GenerateMatches = function (id) {
                    return $http.post("/data/matches/generate?LeagueId=" + id);
                };
            }
            MatchService.$inject = ['$http', '$q'];
            return MatchService;
        }());
        Services.MatchService = MatchService;
    })(Services = pool.Services || (pool.Services = {}));
})(pool || (pool = {}));
