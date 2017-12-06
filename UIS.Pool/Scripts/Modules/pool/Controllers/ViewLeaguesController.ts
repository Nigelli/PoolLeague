namespace pool.Controllers {
    "use strict";

    export class ViewLeaguesController implements angular.IController {
        static $inject = ['$scope', 'SeasonService', 'LeagueService'];
        Active: boolean;
        CurrentSeason;
        Seasons;
        Leagues;
        updateCurrentSeason;

        constructor($scope, _seasonService, _leagueService) {
            var vm = this;
            vm.Active = false;
            vm.updateCurrentSeason = id => this.updateActiveSeason(_leagueService, id);

            function init() {
                _seasonService.GetSeasons()
                    .then(
                        result => {
                            vm.Seasons = result.data;
                            vm.CurrentSeason = vm.Seasons[vm.Seasons.length -1];
                            _leagueService.GetLeaguesBySeason(vm.Seasons[vm.Seasons.length - 1].Id)
                                .then(
                                    result => {
                                        vm.Leagues = result.data;
                                    },
                                    error => {
                                        this.errorAlert();
                                    }
                                );
                        },
                        error => {
                            vm.Seasons = null;
                            this.errorAlert();
                        }
                );
                
            };

            init();
        }

        private errorAlert(message) {
            message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
            alert(message);
        };

        private updateActiveSeason(_leagueService, id) {
            _leagueService.GetLeaguesBySeason(id)
                .then(
                    result => {
                        this.Leagues = result.data;
                    },
                    error => this.errorAlert('Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.')
                );
        }

        $onInit(): void {};
    }
}