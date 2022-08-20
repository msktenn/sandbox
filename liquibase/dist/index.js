"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const liquibase_1 = require("liquibase");
const myConfig = Object.assign(Object.assign({}, liquibase_1.POSTGRESQL_DEFAULT_CONFIG), { changeLogFile: "master.yml", url: "jdbc:postgresql://localhost:5432/prismatest", username: "postgres", password: "33787bafa98847078fb363640ea87c6f", logLevel: liquibase_1.LiquibaseLogLevels.Info });
const instance = new liquibase_1.Liquibase(myConfig);
function doEet() {
    return __awaiter(this, void 0, void 0, function* () {
        yield instance.status();
        // await instance.update();
        // await instance.dropAll();
    });
}
doEet();
//# sourceMappingURL=index.js.map