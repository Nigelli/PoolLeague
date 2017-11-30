var pool;
(function (pool) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ManageLeaguesController = /** @class */ (function () {
            function ManageLeaguesController($scope, $rootScope, _seasonService, _leagueService, _matchService, _playerService) {
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
                vm.UpdateMatchResult = function () { return _this._updateMatchResult(); };
                vm.AddSeason = function (description) { return _this._addSeason(description); };
                vm.AddPlayer = function (name) { return _this._addPlayer(name); };
                vm.AddLeague = function (description, seasonId) { return _this._addLeague(description, seasonId); };
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
            ManageLeaguesController.prototype._addLeague = function (description, seasonId) {
                var newLeague = {
                    Season_Id: seasonId,
                    Description: description,
                    LeagueLevel: 1
                };
                this._leagueService.CreateLeague(newLeague).then();
            };
            ManageLeaguesController.prototype._addSeason = function (description) {
                var _this = this;
                this._seasonService.AddSeason(description)
                    .then(function (result) {
                    alert('season added');
                    _this._seasonService.GetSeasons()
                        .then(function (result) { return _this.Seasons = result.data; }, function (error) { return _this.errorAlert(null); });
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._addPlayer = function (name) {
                var _this = this;
                this._playerService.AddPlayer(name)
                    .then(function (result) {
                    alert(name + " has been added to the pool of players");
                    _this._playerService.GetPlayers()
                        .then(function (result) { return _this.Players = result.data; }, function (error) { return _this.errorAlert(null); });
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._updateSelectedLeague = function (leagueId) {
                var _this = this;
                this._matchService.GetMatchesByLeague(leagueId)
                    .then(function (result) {
                    _this.ManageResults.SelectedMatch = null;
                    _this.Matches = result.data;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._updateMatchResult = function () {
                var _this = this;
                this._matchService.UpdateMatch(this.ManageResults.SelectedMatch)
                    .then(function (result) {
                    alert("Match between " + _this.ManageResults.SelectedMatch.Player1 + " & " + _this.ManageResults.SelectedMatch.Player2 + " updated, with " + _this.ManageResults.SelectedMatch.Winner + " as the winner");
                    _this.ManageResults.SelectedMatch = null;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._updateSelectedSeason = function (seasonId) {
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
            ManageLeaguesController.prototype.errorAlert = function (message) {
                message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
                alert(message);
            };
            ;
            ManageLeaguesController.prototype.$onInit = function () { };
            ;
            ManageLeaguesController.$inject = ['$scope', '$rootScope', 'SeasonService', 'LeagueService', 'MatchService', 'PlayerService'];
            return ManageLeaguesController;
        }());
        Controllers.ManageLeaguesController = ManageLeaguesController;
    })(Controllers = pool.Controllers || (pool.Controllers = {}));
})(pool || (pool = {}));
//# sourceMappingURL=ManageLeaguesController.js.map