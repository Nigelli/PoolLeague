namespace pool.Controllers {
    "use strict";

    export class ManageResultsController implements angular.IController {
        static $inject = ['$scope', '$rootScope', 'SeasonService', 'LeagueService', 'MatchService', 'PlayerService', 'toastr'];
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
        GenerateMatches: Function;


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
            vm.ManageResults = {
                SelectedSeason: null,
                SelectedLeague: null,
                SelectedMatch: null
            }
            vm.UpdateSelectedLeague = leagueId => this._updateSelectedLeague(leagueId);
            vm.UpdateSelectedSeason = seasonId => this._updateSelectedSeason(seasonId);
            vm.UpdateSelectedMatch = match => console.log(match);
            vm.UpdateMatchResult = match => this._updateMatchResult(match);
            vm.GenerateMatches = leagueId => this._generateMatches(leagueId);

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

        private _generateMatches(leagueId) {
            this._matchService.GenerateMatches(leagueId)
                .then(
                    result => {
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

        private _updateMatchResult(match) {
            this._matchService.UpdateMatch(match)
                .then(
                    result => {
                        this.sucessAlert(`Match has been updated`);
                        match.modified = null;
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