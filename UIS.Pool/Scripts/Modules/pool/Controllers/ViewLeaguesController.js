var pool;
(function (pool) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ViewLeaguesController = /** @class */ (function () {
            function ViewLeaguesController($scope, _seasonService, _leagueService) {
                var _this = this;
                var vm = this;
                vm.Active = false;
                vm.updateCurrentSeason = function (id) { return _this.updateActiveSeason(_leagueService, id); };
                function init() {
                    var _this = this;
                    _seasonService.GetSeasons()
                        .then(function (result) {
                        vm.Seasons = result.data;
                        vm.CurrentSeason = vm.Seasons[vm.Seasons.length - 1];
                        _leagueService.GetLeaguesBySeason(vm.Seasons[vm.Seasons.length - 1].Id)
                            .then(function (result) {
                            vm.Leagues = result.data;
                        }, function (error) {
                            _this.errorAlert();
                        });
                    }, function (error) {
                        vm.Seasons = null;
                        _this.errorAlert();
                    });
                }
                ;
                init();
            }
            ViewLeaguesController.prototype.errorAlert = function (message) {
                message = message || 'Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.';
                alert(message);
            };
            ;
            ViewLeaguesController.prototype.updateActiveSeason = function (_leagueService, id) {
                var _this = this;
                _leagueService.GetLeaguesBySeason(id)
                    .then(function (result) {
                    _this.Leagues = result.data;
                }, function (error) { return _this.errorAlert('Oh shit, looks like something went wrong. Go and put some balls in holes and try again later.'); });
            };
            ViewLeaguesController.prototype.$onInit = function () { };
            ;
            ViewLeaguesController.$inject = ['$scope', 'SeasonService', 'LeagueService'];
            return ViewLeaguesController;
        }());
        Controllers.ViewLeaguesController = ViewLeaguesController;
    })(Controllers = pool.Controllers || (pool.Controllers = {}));
})(pool || (pool = {}));
//# sourceMappingURL=ViewLeaguesController.js.map