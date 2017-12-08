namespace pool.Controllers {
    "use strict";

    export class ManageLeaguesController implements angular.IController {
        static $inject = ['$scope', '$rootScope', 'SeasonService', 'LeagueService', 'MatchService', 'PlayerService', 'toastr'];
        Seasons;
        Leagues;
        Matches;
        Players;
        ManageLeague;
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
            private _playerService: Services.PlayerService,
            private _toastr: angular.toastr.IToastrService
        ) {
            var vm = this;
            vm.ManageLeague = {
                SelectedSeason: null,
                SelectedLeague: null
            }
            vm.UpdateSelectedLeague = leagueId => this._updateSelectedLeague(leagueId);
            vm.UpdateSelectedSeason = seasonId => this._updateSelectedSeason(seasonId);
            vm.UpdateSelectedMatch = match => console.log(match);
            vm.AddSeason = description => this._addSeason(description);
            vm.AddPlayer = name => this._addPlayer(name);
            vm.AddLeague = (description, seasonId) => this._addLeague(description, seasonId);
            vm.AddPlayerToLeague = (playerId, leagueId) => this._addPlayerToLeague(playerId, leagueId);

            function init() {
                _seasonService.GetSeasons()
                    .then(
                        result => {
                            vm.Seasons = result.data;
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
                    this.sucessAlert(`${description} has been created as a league.`);
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
                        this.sucessAlert(`Player has been added to the league.`);
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
                        this.sucessAlert(`${description} added to seasons.`);
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
                        this.sucessAlert(`${name} has been added to the pool of players`);
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
                        this.ManageLeague.SelectedMatch = null;
                        this.Matches = result.data;
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
                        this.ManageLeague.SelectedLeague = null;
                    },
                    error => {
                        this.errorAlert(null);
                    }
                );
        }

        private sucessAlert(message) {
            message = message || 'Operation completed successfully';
            this._toastr.success(message, "Success");
        }

        private errorAlert(message) {
            message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
            this._toastr.error(message, "Error");
        };

        $onInit(): void {};
    }
}