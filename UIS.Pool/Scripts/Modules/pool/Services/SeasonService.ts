namespace pool.Services {
    "use strict";

    export class SeasonService {
        static $inject = ['$http', '$q'];
        GetSeasons: Function;
        AddSeason: Function;

        constructor($http, $q) {
            this.GetSeasons = () => $http.get("/data/seasons/get");
            this.AddSeason = description => $http.post(`/data/seasons/add?description=${description}`);
        }
    }
}