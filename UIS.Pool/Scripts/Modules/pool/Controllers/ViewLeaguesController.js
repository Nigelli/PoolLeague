var pool;
(function (pool) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ViewLeaguesController = /** @class */ (function () {
            function ViewLeaguesController($scope, _seasonService, _leagueService, _toastr) {
                var _this = this;
                this.$scope = $scope;
                this._seasonService = _seasonService;
                this._leagueService = _leagueService;
                this._toastr = _toastr;
                var vm = this;
                vm.Active = false;
                vm.updateCurrentSeason = function (id) { return _this.updateActiveSeason(_leagueService, id); };
                vm.currentPage = 1;
                function init() {
                    var _this = this;
                    _seasonService.GetSeasons()
                        .then(function (result) {
                        vm.Seasons = result.data;
                        vm.CurrentSeason = vm.Seasons[vm.Seasons.length - 1];
                        _leagueService.GetLeaguesBySeason(vm.Seasons[vm.Seasons.length - 1].Id)
                            .then(function (result) {
                            angular.forEach(result.data, function (league) { return league.currentPage = 1; });
                            vm.Leagues = result.data;
                        }, function (error) {
                            _this.errorAlert(null);
                        });
                    }, function (error) {
                        vm.Seasons = null;
                        _this.errorAlert(null);
                    });
                }
                ;
                init();
            }
            ViewLeaguesController.prototype.errorAlert = function (message) {
                message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
                this._toastr.error(message, "Error");
            };
            ;
            ViewLeaguesController.prototype.updateActiveSeason = function (_leagueService, id) {
                var _this = this;
                _leagueService.GetLeaguesBySeason(id)
                    .then(function (result) {
                    angular.forEach(result.data, function (league) { return league.currentPage = 1; });
                    _this.Leagues = result.data;
                }, function (error) { return _this.errorAlert(null); });
            };
            ViewLeaguesController.prototype.$onInit = function () { };
            ;
            ViewLeaguesController.$inject = ['$scope', 'SeasonService', 'LeagueService', 'toastr'];
            return ViewLeaguesController;
        }());
        Controllers.ViewLeaguesController = ViewLeaguesController;
    })(Controllers = pool.Controllers || (pool.Controllers = {}));
})(pool || (pool = {}));
//# sourceMappingURL=ViewLeaguesController.js.map