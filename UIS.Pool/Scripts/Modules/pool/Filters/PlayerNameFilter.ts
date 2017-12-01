namespace pool.Filters {
    "use strict";

    export function PlayerNameFilter() {
        return (input, Players) => {
            if (input == 'null' || input == null) {
                return 'Not Played';
            }
            for (var i = 0; i < Players.length; i++) {
                if (Players[i].Id == input) {
                    return Players[i].Name;
                }
            }
            return input;
        }
    }
}