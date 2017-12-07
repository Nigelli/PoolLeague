var pool;
(function (pool) {
    var Filters;
    (function (Filters) {
        "use strict";
        function PlayersByName() {
            return function (input, players, playerName) {
                if (!playerName) {
                    return input;
                }
                var matchedPlayers = matchPlayersByName(players, playerName);
                var out = [];
                if (matchedPlayers.length) {
                    for (var i = 0; i < input.length; i++) {
                        var addToResults = false;
                        for (var j = 0; j < matchedPlayers.length; j++) {
                            if (input[i].Player1 == matchedPlayers[j].Id || input[i].Player2 == matchedPlayers[j].Id || input[i].Winner == matchedPlayers[j].Id) {
                                addToResults = true;
                            }
                        }
                        if (addToResults) {
                            out.push(input[i]);
                        }
                    }
                }
                return out;
            };
        }
        Filters.PlayersByName = PlayersByName;
        function matchPlayersByName(players, playerName) {
            var matches = [];
            angular.forEach(players, function (player) {
                if (player.Name.toLowerCase().indexOf(playerName.toLowerCase()) !== -1) {
                    matches.push(player);
                }
            });
            return matches;
        }
    })(Filters = pool.Filters || (pool.Filters = {}));
})(pool || (pool = {}));
