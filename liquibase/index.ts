import { LiquibaseConfig, Liquibase, POSTGRESQL_DEFAULT_CONFIG, LiquibaseLogLevels } from "liquibase";
import AppConfig from "./Environment";

const appConfig: AppConfig = AppConfig.getInstance();

const myConfig: LiquibaseConfig = {
  ...POSTGRESQL_DEFAULT_CONFIG,

  changeLogFile: appConfig.liquibase.changeLogFile,
  logLevel: appConfig.liquibase.logLevel,
  url: appConfig.database.url,
  username: appConfig.database.username,
  password: appConfig.database.password,
};
const instance = new Liquibase(myConfig);

async function doEet() {
  console.log(appConfig.liquibase.changeLogFile);
  console.log(appConfig.liquibase.logLevel);
  console.log(appConfig.database.url);
  console.log(appConfig.database.username);
  console.log(appConfig.database.password);

  await instance.status();
  // await instance.update();
  // await instance.dropAll();
}

doEet();
