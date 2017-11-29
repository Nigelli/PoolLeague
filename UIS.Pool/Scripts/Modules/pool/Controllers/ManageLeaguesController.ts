namespace pool.Controllers {
    "use strict";

    export class ManageLeaguesController implements angular.IController {
        static $inject = ['$scope', '$rootScope', 'SeasonService', 'LeagueService', 'MatchService'];
        Seasons;
        Leagues;
        Matches;
        ManageResults;
        SelectedSeason;
        UpdateSelectedLeague: Function;
        UpdateSelectedSeason: Function;
        UpdateSelectedMatch: Function;
        UpdateMatchResult: Function;


        constructor($scope, $rootScope, _seasonService, _leagueService, _matchService) {
            var vm = this;
            vm.ManageResults = {
                SelectedSeason: null,
                SelectedLeague: null,
                SelectedMatch: null
            }
            vm.UpdateSelectedLeague = leagueId => this._updateSelectedLeague(_matchService, leagueId);
            vm.UpdateSelectedSeason = seasonId => this._updateSelectedSeason(_leagueService, seasonId);
            vm.UpdateSelectedMatch = match => console.log(match);
            vm.UpdateMatchResult = () => this._updateMatchResult(_matchService);

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
            };

            init();
        }

        private _updateSelectedLeague(_matchService, leagueId) {
            _matchService.GetMatchesByLeague(leagueId)
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

        private _updateMatchResult(_matchService) {
            _matchService.UpdateMatch(this.ManageResults.SelectedMatch)
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


        private _updateSelectedSeason(_leagueService, seasonId) {
            _leagueService.GetLeaguesBySeason(seasonId)
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