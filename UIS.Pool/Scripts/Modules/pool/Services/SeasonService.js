var pool;
(function (pool) {
    var Services;
    (function (Services) {
        "use strict";
        var SeasonService = /** @class */ (function () {
            function SeasonService($http, $q) {
                this.GetSeasons = function () { return $http.get("/data/seasons/get"); };
                this.AddSeason = function (description) { return $http.post("/data/seasons/add?description=" + description); };
            }
            SeasonService.$inject = ['$http', '$q'];
            return SeasonService;
        }());
        Services.SeasonService = SeasonService;
    })(Services = pool.Services || (pool.Services = {}));
})(pool || (pool = {}));
//# sourceMappingURL=SeasonService.js.map