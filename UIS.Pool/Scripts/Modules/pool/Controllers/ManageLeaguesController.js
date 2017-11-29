var pool;
(function (pool) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ManageLeaguesController = /** @class */ (function () {
            function ManageLeaguesController($scope, $rootScope, _seasonService, _leagueService, _matchService) {
                var _this = this;
                var vm = this;
                vm.ManageResults = {
                    SelectedSeason: null,
                    SelectedLeague: null,
                    SelectedMatch: null
                };
                vm.UpdateSelectedLeague = function (leagueId) { return _this._updateSelectedLeague(_matchService, leagueId); };
                vm.UpdateSelectedSeason = function (seasonId) { return _this._updateSelectedSeason(_leagueService, seasonId); };
                vm.UpdateSelectedMatch = function (match) { return console.log(match); };
                vm.UpdateMatchResult = function () { return _this._updateMatchResult(_matchService); };
                function init() {
                    var _this = this;
                    _seasonService.GetSeasons()
                        .then(function (result) {
                        vm.Seasons = result.data;
                        //vm.ManageResults.SelectedSeason = vm.Seasons[vm.Seasons.length - 1];
                    }, function (error) {
                        vm.Seasons = null;
                        _this.errorAlert(null);
                    });
                }
                ;
                init();
            }
            ManageLeaguesController.prototype._updateSelectedLeague = function (_matchService, leagueId) {
                var _this = this;
                _matchService.GetMatchesByLeague(leagueId)
                    .then(function (result) {
                    _this.ManageResults.SelectedMatch = null;
                    _this.Matches = result.data;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._updateMatchResult = function (_matchService) {
                var _this = this;
                _matchService.UpdateMatch(this.ManageResults.SelectedMatch)
                    .then(function (result) {
                    alert("Match between " + _this.ManageResults.SelectedMatch.Player1 + " & " + _this.ManageResults.SelectedMatch.Player2 + " updated, with " + _this.ManageResults.SelectedMatch.Winner + " as the winner");
                    _this.ManageResults.SelectedMatch = null;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._updateSelectedSeason = function (_leagueService, seasonId) {
                var _this = this;
                _leagueService.GetLeaguesBySeason(seasonId)
                    .then(function (result) {
                    _this.Leagues = result.data;
                    _this.ManageResults.SelectedLeague = null;
                    _this.Matches = null;
                    _this.ManageResults.SelectedMatch = null;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype.errorAlert = function (message) {
                message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
                alert(message);
            };
            ;
            ManageLeaguesController.prototype.$onInit = function () { };
            ;
            ManageLeaguesController.$inject = ['$scope', '$rootScope', 'SeasonService', 'LeagueService', 'MatchService'];
            return ManageLeaguesController;
        }());
        Controllers.ManageLeaguesController = ManageLeaguesController;
    })(Controllers = pool.Controllers || (pool.Controllers = {}));
})(pool || (pool = {}));
