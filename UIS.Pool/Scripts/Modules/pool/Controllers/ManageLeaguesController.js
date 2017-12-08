var pool;
(function (pool) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ManageLeaguesController = /** @class */ (function () {
            function ManageLeaguesController($scope, $rootScope, _seasonService, _leagueService, _matchService, _playerService, _toastr) {
                var _this = this;
                this.$scope = $scope;
                this.$rootScope = $rootScope;
                this._seasonService = _seasonService;
                this._leagueService = _leagueService;
                this._matchService = _matchService;
                this._playerService = _playerService;
                this._toastr = _toastr;
                var vm = this;
                vm.ManageLeague = {
                    SelectedSeason: null,
                    SelectedLeague: null
                };
                vm.UpdateSelectedLeague = function (leagueId) { return _this._updateSelectedLeague(leagueId); };
                vm.UpdateSelectedSeason = function (seasonId) { return _this._updateSelectedSeason(seasonId); };
                vm.UpdateSelectedMatch = function (match) { return console.log(match); };
                vm.AddSeason = function (description) { return _this._addSeason(description); };
                vm.AddPlayer = function (name) { return _this._addPlayer(name); };
                vm.AddLeague = function (description, seasonId) { return _this._addLeague(description, seasonId); };
                vm.AddPlayerToLeague = function (playerId, leagueId) { return _this._addPlayerToLeague(playerId, leagueId); };
                function init() {
                    var _this = this;
                    _seasonService.GetSeasons()
                        .then(function (result) {
                        vm.Seasons = result.data;
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
                var _this = this;
                var newLeague = {
                    Season_Id: seasonId,
                    Description: description,
                    LeagueLevel: 1
                };
                this._leagueService.CreateLeague(newLeague).then(function (result) {
                    _this.sucessAlert(description + " has been created as a league.");
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._addPlayerToLeague = function (playerId, leagueId) {
                var _this = this;
                this._leagueService.AddPlayer(playerId, leagueId)
                    .then(function (result) {
                    _this.sucessAlert("Player has been added to the league.");
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._addSeason = function (description) {
                var _this = this;
                this._seasonService.AddSeason(description)
                    .then(function (result) {
                    _this.sucessAlert(description + " added to seasons.");
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
                    _this.sucessAlert(name + " has been added to the pool of players");
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
                    _this.ManageLeague.SelectedMatch = null;
                    _this.Matches = result.data;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype._updateSelectedSeason = function (seasonId) {
                var _this = this;
                this._leagueService.GetLeaguesBySeason(seasonId)
                    .then(function (result) {
                    _this.Leagues = result.data;
                    _this.ManageLeague.SelectedLeague = null;
                }, function (error) {
                    _this.errorAlert(null);
                });
            };
            ManageLeaguesController.prototype.sucessAlert = function (message) {
                message = message || 'Operation completed successfully';
                this._toastr.success(message, "Success");
            };
            ManageLeaguesController.prototype.errorAlert = function (message) {
                message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
                this._toastr.error(message, "Error");
            };
            ;
            ManageLeaguesController.prototype.$onInit = function () { };
            ;
            ManageLeaguesController.$inject = ['$scope', '$rootScope', 'SeasonService', 'LeagueService', 'MatchService', 'PlayerService', 'toastr'];
            return ManageLeaguesController;
        }());
        Controllers.ManageLeaguesController = ManageLeaguesController;
    })(Controllers = pool.Controllers || (pool.Controllers = {}));
})(pool || (pool = {}));
//# sourceMappingURL=ManageLeaguesController.js.map