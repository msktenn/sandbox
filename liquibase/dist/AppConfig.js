"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class AppConfig {
    /**
     * The Singleton's constructor should always be private to prevent direct
     * construction calls with the `new` operator.
     */
    constructor() {
        /**
         * Finally, any singleton should define some business logic, which can be
         * executed on its instance.
         */
        this.liquibase = class {
        };
        this.database = class {
        };
        this.liquibase.test = "Hello";
    }
    /**
     * The static method that controls the access to the singleton instance.
     *
     * This implementation let you subclass the Singleton class while keeping
     * just one instance of each subclass around.
     */
    static getInstance() {
        if (!AppConfig.instance) {
            AppConfig.instance = new AppConfig();
        }
        return AppConfig.instance;
    }
}
exports.default = AppConfig;
//# sourceMappingURL=AppConfig.js.map