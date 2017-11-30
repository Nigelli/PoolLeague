namespace pool.Services {
    "use strict";

    export class MatchService {
        static $inject = ['$http', '$q'];
        GetMatchesByLeague: Function;
        UpdateMatch: Function;

        constructor($http, $q) {
            this.GetMatchesByLeague = (id) => {
                return $http.post(`/data/matches/get?Id=${id}`);
            }

            this.UpdateMatch = (match) => {
                return $http.post("/data/matches/add", match);
            }
        }
    }
}