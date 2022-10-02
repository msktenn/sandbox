export default {
  liquibase: {
    changeLogFile: "master.yml",
    logLevel: "info",
  },
  database: {
    url: "jdbc:postgresql://localhost:5432/prismatest?createDatabaseIfNotExist=true",
  },
};
