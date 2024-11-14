"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = {
    liquibase: {
        changeLogFile: "master.yml",
        logLevel: "info",
    },
    database: {
        url: "jdbc:postgresql://localhost:5432/prismatest?createDatabaseIfNotExist=true",
    },
};
//# sourceMappingURL=default.js.map