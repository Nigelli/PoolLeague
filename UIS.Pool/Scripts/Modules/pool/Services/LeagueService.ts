﻿namespace pool.Services {
    "use strict";

    export class LeagueService {
        static $inject = ['$http', '$q'];
        GetLeaguesBySeason: Function;
        CreateLeague: Function;

        constructor($http, $q) {

            this.GetLeaguesBySeason = (id) => {
                return $http.post(`/data/leagues/get?Id=${id}`);
            }
            this.CreateLeague = (league) => $http.post("/data/leagues/add", league);
            
        }
    }
}