namespace pool.Controllers {
    "use strict";

    export class ManageLeaguesController implements angular.IController {
        static $inject = ['$scope', '$rootScope', 'SeasonService', 'LeagueService', 'MatchService', 'PlayerService'];
        Seasons;
        Leagues;
        Matches;
        Players;
        ManageResults;
        SelectedSeason;
        UpdateSelectedLeague: Function;
        UpdateSelectedSeason: Function;
        UpdateSelectedMatch: Function;
        UpdateMatchResult: Function;
        AddSeason: Function;
        AddPlayer: Function;
        AddLeague: Function;
        AddPlayerToLeague: Function;


        constructor(
            private $scope: angular.IScope,
            private $rootScope: angular.IRootScopeService,
            private _seasonService: Services.SeasonService,
            private _leagueService: Services.LeagueService,
            private _matchService: Services.MatchService,
            private _playerService: Services.PlayerService
        ) {
            var vm = this;
            vm.ManageResults = {
                SelectedSeason: null,
                SelectedLeague: null,
                SelectedMatch: null
            }
            vm.UpdateSelectedLeague = leagueId => this._updateSelectedLeague(leagueId);
            vm.UpdateSelectedSeason = seasonId => this._updateSelectedSeason(seasonId);
            vm.UpdateSelectedMatch = match => console.log(match);
            vm.UpdateMatchResult = () => this._updateMatchResult();
            vm.AddSeason = description => this._addSeason(description);
            vm.AddPlayer = name => this._addPlayer(name);
            vm.AddLeague = (description, seasonId) => this._addLeague(description, seasonId);
            vm.AddPlayerToLeague = (playerId, leagueId) => this._addPlayerToLeague(playerId, leagueId);

            function init() {
                _seasonService.GetSeasons()
                    .then(
                        result => {
                            vm.Seasons = result.data;
                            //vm.ManageResults.SelectedSeason = vm.Seasons[vm.Seasons.length - 1];
                        },
                        error => {
                            vm.Seasons = null;
                            this.errorAlert(null);
                        }
                );
                _playerService.GetPlayers()
                    .then(
                    result => vm.Players = result.data,
                    error => this.errorAlert(null)
                    );
            };

            init();
        }

        private _addLeague(description, seasonId) {
            let newLeague = {
                Season_Id: seasonId,
                Description: description,
                LeagueLevel: 1
            }

            this._leagueService.CreateLeague(newLeague).then(
                result => {
                    alert(`${description} has been created.`);
                },
                error => {
                    this.errorAlert(null);
                }
            );

        }

        private _addPlayerToLeague(playerId, leagueId) {
            this._leagueService.AddPlayer(playerId, leagueId)
                .then(
                    result => {
                        alert(`player has been added to the league.`);
                    },
                    error => {
                        this.errorAlert(null);
                    }
                );
        }

        private _addSeason(description) {
            this._seasonService.AddSeason(description)
                .then(
                    result => {
                        alert('season added');
                        this._seasonService.GetSeasons()
                            .then(
                                result => this.Seasons = result.data,
                                error => this.errorAlert(null)
                            );
                    },
                    error => {
                        this.errorAlert(null);
                    }
                );
        }

        private _addPlayer(name) {
            this._playerService.AddPlayer(name)
                .then(
                    result => {
                        alert(`${name} has been added to the pool of players`);
                        this._playerService.GetPlayers()
                            .then(
                                result => this.Players = result.data,
                                error => this.errorAlert(null)
                            );
                    },
                    error => {
                        this.errorAlert(null);
                    }
                );
        }

        private _updateSelectedLeague(leagueId) {
            this._matchService.GetMatchesByLeague(leagueId)
                .then(
                    result => {
                        this.ManageResults.SelectedMatch = null;
                        this.Matches = result.data;
                    },
                    error => {
                        this.errorAlert(null);
                    }
                );
        }

        private _updateMatchResult() {
            this._matchService.UpdateMatch(this.ManageResults.SelectedMatch)
                .then(
                    result => {
                        alert(`Match between ${this.ManageResults.SelectedMatch.Player1} & ${this.ManageResults.SelectedMatch.Player2} updated, with ${this.ManageResults.SelectedMatch.Winner} as the winner`);
                        this.ManageResults.SelectedMatch = null;
                    },
                    error => {
                        this.errorAlert(null);
                    }
                );
        }


        private _updateSelectedSeason(seasonId) {
            this._leagueService.GetLeaguesBySeason(seasonId)
                .then(
                    result => {
                        this.Leagues = result.data;
                        this.ManageResults.SelectedLeague = null;
                        this.Matches = null;
                        this.ManageResults.SelectedMatch = null;
                    },
                    error => {
                        this.errorAlert(null);
                    }
                );
        }

        private errorAlert(message) {
            message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
            alert(message);
        };

        $onInit(): void {};
    }
}