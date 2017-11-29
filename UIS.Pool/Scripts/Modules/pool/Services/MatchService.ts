namespace pool.Services {
    "use strict";

    export class MatchService {
        static $inject = ['$http', '$q'];
        GetMatchesByLeague: Function;
        UpdateMatch: Function;

        constructor($http, $q) {
            this.GetMatchesByLeague = (id) => {
                return $http.get(`/Match/getMatchesByLeague?id=${id}`);
            }

            this.UpdateMatch = (match) => {
                return $http.post("/Match/updateMatch", match);
            }

            this.GetMatchesByLeague = (id) => {
                let deferred = new $q.defer();
                setTimeout(
                    () => {
                        deferred.resolve(this.LeaguesMock);
                    },
                    500);

                return deferred.promise;
            }

        }

        private League1 = [
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

        private LeaguesMock = {
            data: this.League1
        }
    }
}