namespace pool.Services {
    "use strict";

    export class AuthorizationService {
        static $inject = ['$http'];
        isAuthorized: Function;
        
        constructor($http,) {
            this.isAuthorized = () => {
                $http.get("/Account/IsUserAuthenticated")
                    .then(
                        result => {
                            return result.data;
                        }
                    );
            }

        }
    }
}