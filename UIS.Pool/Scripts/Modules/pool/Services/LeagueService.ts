namespace pool.Services {
    "use strict";

    export class LeagueService {
        static $inject = ['$http', '$q'];
        GetLeagues: Function;
        GetLeaguesBySeason: Function;
        GetCurrentLeagues: Function;

        constructor($http, $q) {
            this.GetLeagues = () => {
                return $http.get("/Leagues/get");
            }

            this.GetLeaguesBySeason = (id) => {
                return $http.get(`/Leagues/getBySeason?seasonId=${id}`);
            }

            this.GetLeaguesBySeason = (id) => {
                let deferred = new $q.defer();
                setTimeout(
                    () => {
                        deferred.resolve(this.LeaguesMock);
                    },
                    500);

                return deferred.promise;
            }

            this.GetCurrentLeagues = (id) => {
                return $http.get("/Leagues/getCurrentLeagues");
            }

            this.GetCurrentLeagues = () => {
                let deferred = new $q.defer();
                setTimeout(
                    () => {
                        deferred.resolve(this.LeaguesMock);
                    },
                    500);

                return deferred.promise;
            }

        }

        private League1 = {
            Id: 1,
            SeasonId: 8,
            Description: 'League 1',
            LeagueLevel: 1,
            Data: [
                { Name: 'Richard Herne', Wins: 4, Losses: 1, Position: 1 },
                { Name: 'Paul Hampshire', Wins: 1, Losses: 1, Position: 2 },
                { Name: 'Nigel Anderson', Wins: 0, Losses: 1, Position: 3 },
                { Name: 'Tom Smith', Wins: 0, Losses: 2, Position: 4 },
                { Name: 'Shaun Dunn', Wins: 0, Losses: 0, Position: 5 },
                { Name: 'Andrew Wright', Wins: 0, Losses: 0, Position: 6 },
                { Name: 'Jack Hayles', Wins: 0, Losses: 0, Position: 7 }
            ],
            Results: [
                { Player1: 'Richard Herne', Player2: 'Paul Hampshire', Winner: 'Richard Herne' },
                { Player1: 'Richard Herne', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Richard Herne', Player2: 'Nigel Anderson', Winner: 'Nigel Anderson' },
                { Player1: 'Paul Hampshire', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Paul Hampshire', Player2: 'Nigel Anderson', Winner: 'Paul Hampshire' },
                { Player1: 'Nigel Anderson', Player2: 'Shaun Dunn', Winner: 'Nigel Anderson' },
                { Player1: 'Richard Herne', Player2: 'Paul Hampshire', Winner: 'Richard Herne' },
                { Player1: 'Richard Herne', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Richard Herne', Player2: 'Nigel Anderson', Winner: 'Nigel Anderson' },
                { Player1: 'Paul Hampshire', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Paul Hampshire', Player2: 'Nigel Anderson', Winner: 'Paul Hampshire' },
                { Player1: 'Nigel Anderson', Player2: 'Shaun Dunn', Winner: 'Nigel Anderson' }
            ]
        }

        private League2 = {
            Id: 2,
            SeasonId: 8,
            Description: 'League 2',
            LeagueLevel: 2,
            Data: [
                { Name: 'Tony Heath-Smith', Wins: 6, Losses: 2, Position: 1 },
                { Name: 'Fernando Piccin', Wins: 3, Losses: 1, Position: 2 },
                { Name: 'Mike Butcher', Wins: 3, Losses: 2, Position: 3 },
                { Name: 'Enzo Folloni', Wins: 2, Losses: 4, Position: 4 },
                { Name: 'Damian Leeming', Wins: 2, Losses: 4, Position: 5 },
                { Name: 'Bea Mendyk', Wins: 2, Losses: 6, Position: 6 },
                { Name: 'Neil Parkin', Wins: 0, Losses: 1, Position: 7 }
            ],
            Results: [
                { Player1: 'Richard Herne', Player2: 'Paul Hampshire', Winner: 'Richard Herne' },
                { Player1: 'Richard Herne', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Richard Herne', Player2: 'Nigel Anderson', Winner: 'Nigel Anderson' },
                { Player1: 'Paul Hampshire', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Paul Hampshire', Player2: 'Nigel Anderson', Winner: 'Paul Hampshire' },
                { Player1: 'Nigel Anderson', Player2: 'Shaun Dunn', Winner: 'Nigel Anderson' },
                { Player1: 'Richard Herne', Player2: 'Paul Hampshire', Winner: 'Richard Herne' },
                { Player1: 'Richard Herne', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Richard Herne', Player2: 'Nigel Anderson', Winner: 'Nigel Anderson' },
                { Player1: 'Paul Hampshire', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Paul Hampshire', Player2: 'Nigel Anderson', Winner: 'Paul Hampshire' },
                { Player1: 'Nigel Anderson', Player2: 'Shaun Dunn', Winner: 'Nigel Anderson' }
            ]
        }

        private League3 = {
            Id: 3,
            SeasonId: 8,
            Description: 'League 3',
            LeagueLevel: 3,
            Data: [
                { Name: 'Roger Inkpen', Wins: 2, Losses: 0, Position: 1 },
                { Name: 'Lizzie Mills', Wins: 2, Losses: 1, Position: 2 },
                { Name: 'Jamie Blewett', Wins: 1, Losses: 0, Position: 3 },
                { Name: 'Hayden Walsh', Wins: 0, Losses: 2, Position: 4 },
                { Name: 'Kieran Moorhead', Wins: 0, Losses: 2, Position: 5 },
                { Name: 'Ryan Penfold', Wins: 0, Losses: 0, Position: 6 },
                { Name: 'Rob Selway', Wins: 0, Losses: 0, Position: 7 },
                { Name: 'Mike Amey', Wins: 0, Losses: 0, Position: 8 },
                { Name: 'Luke Gibson', Wins: 0, Losses: 0, Position: 9 }
            ],
            Results: [
                { Player1: 'Richard Herne', Player2: 'Paul Hampshire', Winner: 'Richard Herne' },
                { Player1: 'Richard Herne', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Richard Herne', Player2: 'Nigel Anderson', Winner: 'Nigel Anderson' },
                { Player1: 'Paul Hampshire', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Paul Hampshire', Player2: 'Nigel Anderson', Winner: 'Paul Hampshire' },
                { Player1: 'Nigel Anderson', Player2: 'Shaun Dunn', Winner: 'Nigel Anderson' },
                { Player1: 'Richard Herne', Player2: 'Paul Hampshire', Winner: 'Richard Herne' },
                { Player1: 'Richard Herne', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Richard Herne', Player2: 'Nigel Anderson', Winner: 'Nigel Anderson' },
                { Player1: 'Paul Hampshire', Player2: 'Tom Smith', Winner: 'Tom Smith' },
                { Player1: 'Paul Hampshire', Player2: 'Nigel Anderson', Winner: 'Paul Hampshire' },
                { Player1: 'Nigel Anderson', Player2: 'Shaun Dunn', Winner: 'Nigel Anderson' }
            ]
        }

        private LeaguesMock = {
            data: [
                this.League1,
                this.League2,
                this.League3
            ]
        }
    }
}