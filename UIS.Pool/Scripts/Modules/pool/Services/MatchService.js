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
            }
            MatchService.$inject = ['$http', '$q'];
            return MatchService;
        }());
        Services.MatchService = MatchService;
    })(Services = pool.Services || (pool.Services = {}));
})(pool || (pool = {}));
//# sourceMappingURL=MatchService.js.map