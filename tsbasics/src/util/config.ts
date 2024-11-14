import "dotenv/config";
import { Log } from "./log";

interface IConfig {
  LogLevel?: string;
  LogFormat?: string;
}

class ConfigValues {
  private static readonly re: RegExp = /^mkutil_(loglevel|logformat)=(.+)$/;

  private _logLevel: string;
  private _logFormat: string;

  public get LogLevel(): string {
    return this._logLevel;
  }
  public get LogFormat(): string {
    return this._logFormat;
  }

  static readonly instance: ConfigValues = new ConfigValues();

  private constructor() {
    this.OverrideWithCommandLine();
    this._logLevel = process.env.LOGLEVEL ?? "";
    this._logFormat = process.env.LOGFORMAT ?? "";
  }

  private SetEnvVariableToCommandLineValue(key: string, value: string) {
    if (key === "mkutil_loglevel") process.env.LOGLEVEL = value;
    if (key === "mkutil_logformat") process.env.LOGLEVEL = value;
  }

  private OverrideWithCommandLine() {
    // Get command line arguments excluding the first two elements (node and script file)
    const args: string[] = process.argv.slice(2);

    // Parse command line arguments
    args.forEach((arg) => {
      // Split argument into key and value
      const matches = arg.match(ConfigValues.re);
      if (matches) {
        const [key, value] = arg.split("=");
        this.SetEnvVariableToCommandLineValue(key, value);
      }
    });
  }

  public Reset(configuration: IConfig) {
    this._logLevel = configuration.LogLevel ?? this._logLevel;
    this._logFormat = configuration.LogFormat ?? this._logFormat;
  }
}

const config = ConfigValues.instance;
export { config };
