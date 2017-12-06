var pool;
(function (pool) {
    var Filters;
    (function (Filters) {
        "use strict";
        function PlayerNameFilter() {
            return function (input, Players) {
                if (input == 'null' || input == null) {
                    return 'Not Played';
                }
                for (var i = 0; i < Players.length; i++) {
                    if (Players[i].Id == input) {
                        return Players[i].Name;
                    }
                }
                return input;
            };
        }
        Filters.PlayerNameFilter = PlayerNameFilter;
    })(Filters = pool.Filters || (pool.Filters = {}));
})(pool || (pool = {}));
//# sourceMappingURL=PlayerNameFilter.js.map