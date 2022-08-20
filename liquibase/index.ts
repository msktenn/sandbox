import { LiquibaseConfig, Liquibase, POSTGRESQL_DEFAULT_CONFIG, LiquibaseLogLevels } from "liquibase";

const myConfig: LiquibaseConfig = {
  ...POSTGRESQL_DEFAULT_CONFIG,
  changeLogFile: "master.yml",
  url: "jdbc:postgresql://localhost:5432/prismatest",
  username: "postgres",
  password: "33787bafa98847078fb363640ea87c6f",
  logLevel: LiquibaseLogLevels.Info,
};
const instance = new Liquibase(myConfig);

async function doEet() {
  await instance.status();
  // await instance.update();
  // await instance.dropAll();
}

doEet();
