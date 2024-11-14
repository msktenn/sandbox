import dotenv from "dotenv";
dotenv.config();
import config from "config";
import { LiquibaseLogLevels } from "liquibase";

export class ConfigurationError extends Error {
  public constructor(missingConfigValue: string) {
    super(`Required configuration value ${missingConfigValue} is missing.`);

    Object.setPrototypeOf(this, ConfigurationError.prototype);
  }
}

export default class Environment {
  private static instance: Environment;

  /**
   * The Singleton's constructor should always be private to prevent direct
   * construction calls with the `new` operator.
   */
  private constructor() {
    //guard statements
    if (!config.has("database.url")) {
      console.log("database url is not set.");
      throw new ConfigurationError("database.url");
    }
    if (!config.has("database.username")) {
      console.log("database username is not set.");
      throw new ConfigurationError("database.username");
    }
    if (!config.has("database.password")) {
      console.log("database password is not set.");
      throw new ConfigurationError("database.password");
    }

    //setting the values
    this.liquibase.changeLogFile = config.has("liquibase.changeLogFile") ? config.get("liquibase.changeLogFile") : "default.xml";
    this.liquibase.logLevel = config.has("liquibase.logLevel") ? <LiquibaseLogLevels>config.get("liquibase.logLevel") : <LiquibaseLogLevels>"warning";
    this.database.url = config.get("database.url");
    this.database.username = config.get("database.username");
    this.database.password = config.get("database.password");
  }

  /**
   * The static method that controls the access to the singleton instance.
   *
   * This implementation let you subclass the Singleton class while keeping
   * just one instance of each subclass around.
   */
  public static getInstance(): Environment {
    if (!Environment.instance) {
      Environment.instance = new Environment();
    }
    return Environment.instance;
  }

  /**
   * Finally, any singleton should define some business logic, which can be
   * executed on its instance.
   */
  liquibase = class {
    public static changeLogFile: string;
    public static logLevel: LiquibaseLogLevels;
  };

  database = class {
    public static url: string;
    public static username: string;
    public static password: string;
  };
}
