var pool;
(function (pool) {
    var Services;
    (function (Services) {
        "use strict";
        var SeasonService = /** @class */ (function () {
            function SeasonService($http, $q) {
                //this.GetSeasons = () => {
                //    return $http.get("data/seasons/get");
                //}
                var _this = this;
                this.SeasonsMock = {
                    data: [
                        { Id: 1, Description: "April 2017", Ordinal: 1 },
                        { Id: 2, Description: "May 2017", Ordinal: 2 },
                        { Id: 3, Description: "June 2017", Ordinal: 3 },
                        { Id: 4, Description: "July 2017", Ordinal: 4 },
                        { Id: 5, Description: "August 2017", Ordinal: 5 },
                        { Id: 6, Description: "September 2017", Ordinal: 6 },
                        { Id: 7, Description: "October 2017", Ordinal: 7 },
                        { Id: 8, Description: "November 2017", Ordinal: 8 }
                    ]
                };
                this.GetSeasons = function () {
                    var deferred = new $q.defer();
                    setTimeout(function () {
                        deferred.resolve(_this.SeasonsMock);
                    }, 500);
                    return deferred.promise;
                };
            }
            SeasonService.$inject = ['$http', '$q'];
            return SeasonService;
        }());
        Services.SeasonService = SeasonService;
    })(Services = pool.Services || (pool.Services = {}));
})(pool || (pool = {}));
