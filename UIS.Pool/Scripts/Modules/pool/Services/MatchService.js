var pool;
(function (pool) {
    var Services;
    (function (Services) {
        "use strict";
        var MatchService = /** @class */ (function () {
            function MatchService($http, $q) {
                var _this = this;
                this.League1 = [
                    { Player1: 'Richard Herne', Player2: 'Paul Hampshire', Winner: 'Richard Herne', Id: 0 },
                    { Player1: 'Richard Herne', Player2: 'Tom Smith', Winner: 'Tom Smith', Id: 1 },
                    { Player1: 'Richard Herne', Player2: 'Nigel Anderson', Winner: 'Nigel Anderson', Id: 2 },
                    { Player1: 'Paul Hampshire', Player2: 'Tom Smith', Winner: 'Tom Smith', Id: 3 },
                    { Player1: 'Paul Hampshire', Player2: 'Nigel Anderson', Winner: 'Paul Hampshire', Id: 4 },
                    { Player1: 'Nigel Anderson', Player2: 'Shaun Dunn', Winner: 'Nigel Anderson', Id: 5 },
                    { Player1: 'Richard Herne', Player2: 'Paul Hampshire', Winner: 'Richard Herne', Id: 6 },
                    { Player1: 'Richard Herne', Player2: 'Tom Smith', Winner: 'Tom Smith', Id: 7 },
                    { Player1: 'Richard Herne', Player2: 'Nigel Anderson', Winner: 'Nigel Anderson', Id: 8 },
                    { Player1: 'Paul Hampshire', Player2: 'Tom Smith', Winner: 'Tom Smith', Id: 9 },
                    { Player1: 'Paul Hampshire', Player2: 'Nigel Anderson', Winner: 'Paul Hampshire', Id: 10 },
                    { Player1: 'Nigel Anderson', Player2: 'Shaun Dunn', Winner: 'Nigel Anderson', Id: 11 }
                ];
                this.LeaguesMock = {
                    data: this.League1
                };
                this.GetMatchesByLeague = function (id) {
                    return $http.get("/Match/getMatchesByLeague?id=" + id);
                };
                this.UpdateMatch = function (match) {
                    return $http.post("/Match/updateMatch", match);
                };
                this.GetMatchesByLeague = function (id) {
                    var deferred = new $q.defer();
                    setTimeout(function () {
                        deferred.resolve(_this.LeaguesMock);
                    }, 500);
                    return deferred.promise;
                };
            }
            MatchService.$inject = ['$http', '$q'];
            return MatchService;
        }());
        Services.MatchService = MatchService;
    })(Services = pool.Services || (pool.Services = {}));
})(pool || (pool = {}));
