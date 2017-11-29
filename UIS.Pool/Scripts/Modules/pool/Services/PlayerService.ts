namespace pool.Services {
    "use strict";

    export class PlayerService {
        static $inject = ['$http', '$q'];
        GetPlayers: Function;
        AddPlayer: Function;

        constructor($http, $q) {
            this.GetPlayers = () => $http.get("/data/players/get");

            this.AddPlayer = name => $http.post(`/data/players/add?name=${name}`);
        }
    }
}