var pool;
(function (pool) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ManageResultsController = /** @class */ (function () {
            function ManageResultsController($scope, $rootScope, _seasonService, _leagueService, _matchService, _playerService) {
                var _this = this;
                this.$scope = $scope;
                this.$rootScope = $rootScope;
                this._seasonService = _seasonService;
                this._leagueService = _leagueService;
                this._matchService = _matchService;
                this._playerService = _playerService;
                var vm = this;
                vm.ManageResults = {
                    SelectedSeason: null,
                    SelectedLeague: null,
                    SelectedMatch: null
                };
                vm.UpdateSelectedLeague = function (leagueId) { return _this._updateSelectedLeague(leagueId); };
                vm.UpdateSelectedSeason = function (seasonId) { return _this._updateSelectedSeason(seasonId); };
                vm.UpdateSelectedMatch = function (match) { return console.log(match); };
                vm.UpdateMatchResult = function (match) { return _this._updateMatchResult(match); };
                vm.GenerateMatches = function (leagueId) { return _this._generateMatches(leagueId); };
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
                    _playerService.GetPlayers()
                        .then(function (result) { return vm.Players = result.data; }, function (error) { return _this.errorAlert(null); });
                }
                ;
                init();
            }
            ManageResultsController.prototype._generateMatches = function (leagueId) {
                var _this = this;
                this._matchService.GenerateMatches(leagueId)
                    .then(this._matchService.GetMatchesByLeague(leagueId)
                    .then(function (result) {
                    _this.ManageResults.SelectedMatch = null;
                    _this.Matches = result.data;
                }, function (error) {
                    _this.errorAlert(null);
                }));
            };
            ManageResultsController.prototype._updateSelectedLeague = function (leagueId) {
                var _this = this;
                this._matchService.GetMatchesByLeague(leagueId)
                    .then(function (result) {
                    _this.ManageResults.SelectedMatch = null;
                    _this.Matches = result.data;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageResultsController.prototype._updateMatchResult = function (match) {
                var _this = this;
                this._matchService.UpdateMatch(match)
                    .then(function (result) {
                    alert("Match has been updated");
                    match.modified = null;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageResultsController.prototype._updateSelectedSeason = function (seasonId) {
                var _this = this;
                this._leagueService.GetLeaguesBySeason(seasonId)
                    .then(function (result) {
                    _this.Leagues = result.data;
                    _this.ManageResults.SelectedLeague = null;
                    _this.Matches = null;
                    _this.ManageResults.SelectedMatch = null;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageResultsController.prototype.errorAlert = function (message) {
                message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
                alert(message);
            };
            ;
            ManageResultsController.prototype.$onInit = function () { };
            ;
            ManageResultsController.$inject = ['$scope', '$rootScope', 'SeasonService', 'LeagueService', 'MatchService', 'PlayerService'];
            return ManageResultsController;
        }());
        Controllers.ManageResultsController = ManageResultsController;
    })(Controllers = pool.Controllers || (pool.Controllers = {}));
})(pool || (pool = {}));
