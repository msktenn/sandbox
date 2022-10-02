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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const liquibase_1 = require("liquibase");
const Environment_1 = __importDefault(require("./Environment"));
const appConfig = Environment_1.default.getInstance();
const myConfig = Object.assign(Object.assign({}, liquibase_1.POSTGRESQL_DEFAULT_CONFIG), { changeLogFile: appConfig.liquibase.changeLogFile, logLevel: appConfig.liquibase.logLevel, url: appConfig.database.url, username: appConfig.database.username, password: appConfig.database.password });
const instance = new liquibase_1.Liquibase(myConfig);
function doEet() {
    return __awaiter(this, void 0, void 0, function* () {
        console.log(appConfig.liquibase.changeLogFile);
        console.log(appConfig.liquibase.logLevel);
        console.log(appConfig.database.url);
        console.log(appConfig.database.username);
        console.log(appConfig.database.password);
        yield instance.status();
        // await instance.update();
        // await instance.dropAll();
    });
}
doEet();
//# sourceMappingURL=index.js.map