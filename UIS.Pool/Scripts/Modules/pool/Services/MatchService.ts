namespace pool.Services {
    "use strict";

    export class MatchService {
        static $inject = ['$http', '$q'];
        GetMatchesByLeague: Function;
        UpdateMatch: Function;
        GenerateMatches: Function;

        constructor($http, $q) {
            this.GetMatchesByLeague = (id) => {
                return $http.post(`/data/matches/get?Id=${id}`);
            }

            this.UpdateMatch = (match) => {
                match.Winner = parseInt(match.Winner);
                return $http.post("/data/matches/add", match);
            }
            
            this.GenerateMatches = (id) => {
                return $http.post(`/data/matches/generate?LeagueId=${id}`);
            }
        }
    }
}