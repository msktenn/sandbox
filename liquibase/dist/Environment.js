"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ConfigurationError = void 0;
const dotenv_1 = __importDefault(require("dotenv"));
dotenv_1.default.config();
const config_1 = __importDefault(require("config"));
class ConfigurationError extends Error {
    constructor(missingConfigValue) {
        super(`Required configuration value ${missingConfigValue} is missing.`);
        Object.setPrototypeOf(this, ConfigurationError.prototype);
    }
}
exports.ConfigurationError = ConfigurationError;
class Environment {
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
        //guard statements
        if (!config_1.default.has("database.url")) {
            console.log("database url is not set.");
            throw new ConfigurationError("database.url");
        }
        if (!config_1.default.has("database.username")) {
            console.log("database username is not set.");
            throw new ConfigurationError("database.username");
        }
        if (!config_1.default.has("database.password")) {
            console.log("database password is not set.");
            throw new ConfigurationError("database.password");
        }
        //setting the values
        this.liquibase.changeLogFile = config_1.default.has("liquibase.changeLogFile") ? config_1.default.get("liquibase.changeLogFile") : "default.xml";
        this.liquibase.logLevel = config_1.default.has("liquibase.logLevel") ? config_1.default.get("liquibase.logLevel") : "warning";
        this.database.url = config_1.default.get("database.url");
        this.database.username = config_1.default.get("database.username");
        this.database.password = config_1.default.get("database.password");
    }
    /**
     * The static method that controls the access to the singleton instance.
     *
     * This implementation let you subclass the Singleton class while keeping
     * just one instance of each subclass around.
     */
    static getInstance() {
        if (!Environment.instance) {
            Environment.instance = new Environment();
        }
        return Environment.instance;
    }
}
exports.default = Environment;
//# sourceMappingURL=Environment.js.map