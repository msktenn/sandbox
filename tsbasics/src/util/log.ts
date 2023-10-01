import { config } from "./config";

enum LogLevel {
  //used to log where you are in the program. helps to determine logic flow.
  Trace = "Trace",
  //intended for logging detailed information about the system for debugging purposes.
  Debug = "Debug",
  //Purely informative and not looking into them on a regular basis shouldn’t result in missing any important information.
  Info = "Info",
  //signifies potential issues that may lead to errors or unexpected behavior in the future if not addressed.
  Warn = "Warn",
  //indicates error conditions that impair some operation but are less severe than critical situations.
  Error = "Error",
  //indicates that the system is unusable and requires immediate attention.
  Fatal = "Fatal",
}

enum LogFormat {
  Text = "Text",
  Pretty = "Pretty",
  Json = "Json",
}

enum Color {
  brown = "\x1b[38;5;94m",
  red = "\x1b[38;5;160m",
  darkRed = "\x1b[38;5;196m",
  yellow = "\x1b[38;5;226m",
  lightYellow = "\x1b[38;5;229m",
  pink = "\x1b[38;5;207m",
  green = "\x1b[38;5;34m",
  neonGreen = "\x1b[38;5;46m",
  aqua = "\x1b[38;5;51m",
  purple = "\x1b[38;5;93m",
  lightPurple = "\x1b[38;5;53m",
  blue = "\x1b[38;5;33m",
  darkGrey = "\x1b[38;5;232m",
  grey = "\x1b[38;5;248m",
  lightGrey = "\x1b[38;5;255m",
  white = "\x1b[37m",
  black = "\x1b[30m",
  blackOnWhite = "\x1b[30;47m",
  blackOnRed = "\x1b[30;48;5;196m",
  whiteOnRed = "\x1b[37;48;5;160m",
}

export class Log {
  private static readonly reset: string = " \x1b[0m";

  public static Trace(message: string): void {
    const currentLogLevel = config.LogLevel.toLowerCase();
    if (currentLogLevel == LogLevel.Trace.toLowerCase())
      this.output(LogLevel.Trace, message);
  }
  public static Debug(message: string): void {
    const currentLogLevel = config.LogLevel.toLowerCase();
    if (
      currentLogLevel == LogLevel.Debug.toLowerCase() ||
      currentLogLevel == LogLevel.Trace.toLowerCase()
    )
      this.output(LogLevel.Debug, message);
  }
  public static Info(message: string): void {
    const currentLogLevel = config.LogLevel.toLowerCase();
    if (
      currentLogLevel == LogLevel.Info.toLowerCase() ||
      currentLogLevel == LogLevel.Debug.toLowerCase() ||
      currentLogLevel == LogLevel.Trace.toLowerCase()
    )
      this.output(LogLevel.Info, message);
  }
  public static Warning(message: string, error?: Error): void {
    const currentLogLevel = config.LogLevel.toLowerCase();
    if (
      currentLogLevel == LogLevel.Info.toLowerCase() ||
      currentLogLevel == LogLevel.Debug.toLowerCase() ||
      currentLogLevel == LogLevel.Trace.toLowerCase()
    )
      this.output(LogLevel.Warn, message, error);
  }
  public static Error(message: string, error?: Error): void {
    const currentLogLevel = config.LogLevel.toLowerCase();
    if (
      currentLogLevel == LogLevel.Info.toLowerCase() ||
      currentLogLevel == LogLevel.Debug.toLowerCase() ||
      currentLogLevel == LogLevel.Trace.toLowerCase() ||
      currentLogLevel == LogLevel.Warn.toLowerCase() ||
      currentLogLevel == LogLevel.Error.toLowerCase()
    )
      this.output(LogLevel.Error, message, error);
  }
  public static Fatal(message: string, error?: Error): void {
    this.output(LogLevel.Fatal, message, error);
  }

  private static output(
    logLevel: LogLevel,
    message: string,
    error?: Error
  ): void {
    if (config.LogFormat.toLowerCase() == LogFormat.Text.toLowerCase())
      this.outputText(logLevel, message, error);
    if (config.LogFormat.toLowerCase() == LogFormat.Pretty.toLowerCase())
      this.outputPretty(logLevel, message, error);
    if (config.LogFormat.toLowerCase() == LogFormat.Json.toLowerCase())
      this.outputJson(logLevel, message, error);
  }
  private static outputPretty(
    logLevel: LogLevel,
    message: string,
    error?: Error
  ): void {
    let logString: string = "";

    switch (logLevel) {
      case LogLevel.Trace: {
        logString += `${Color.grey}${LogLevel.Trace}`;
        break;
      }
      case LogLevel.Debug: {
        logString += `${Color.green}${LogLevel.Debug}`;
        break;
      }
      case LogLevel.Info: {
        logString += `${Color.brown}${LogLevel.Info} `;
        break;
      }
      case LogLevel.Warn: {
        logString += `${Color.lightYellow}${LogLevel.Warn} `;
        break;
      }
      case LogLevel.Error: {
        logString += `${Color.red}${LogLevel.Error}`;
        break;
      }
      case LogLevel.Fatal: {
        logString += `${Color.whiteOnRed}${LogLevel.Fatal}`;
        break;
      }
    }

    logString += `${Color.white}|${Color.yellow}${message}`;

    if (error?.stack != null)
      logString += `\n  ${Color.blue}${error.stack ?? ""}`;
    if (error?.cause != null)
      logString += `\n  ${Color.blue}${error.stack ?? ""}`;

    logString += Log.reset;

    console.log(logString);
  }

  private static outputText(
    logLevel: LogLevel,
    message: string,
    error?: Error
  ): void {
    let logString: string = "";

    logString += Log.GetCurrentDateString();

    logString += `| ${logLevel}`;
    if (logLevel == LogLevel.Info || logLevel == LogLevel.Warn)
      logString += " ";

    logString += `| ${message}`;

    if (error?.stack != null) logString += `\n  ${error.stack ?? ""}`;
    if (error?.cause != null) logString += `\n  ${error.stack ?? ""}`;

    console.log(logString);
  }

  private static outputJson(
    logLevel: LogLevel,
    message: string,
    error?: Error
  ): void {
    let logString: string = "";

    logString += `{`;
    logString += `date: "${Log.GetCurrentDateString()}",`;
    logString += `level: "${logLevel}",`;
    logString += `message: "${message}",`;
    logString += `errormessage: "${error?.message ?? ""}",`;
    logString += `errorname: "${error?.name ?? ""}",`;
    logString += `stacktrace: "${error?.stack ?? ""}",`;
    logString += `errorcause: "${error?.cause ?? ""}",`;
    logString += `}`;

    console.log(logString);
  }

  private static GetCurrentDateString(): string {
    const now = new Date();
    const year = now.getFullYear().toString().padStart(4, "0");
    const month = (now.getMonth() + 1).toString().padStart(2, "0");
    const day = now.getDate().toString().padStart(2, "0");
    const hours = now.getHours().toString().padStart(2, "0");
    const minutes = now.getMinutes().toString().padStart(2, "0");
    const seconds = now.getSeconds().toString().padStart(2, "0");

    return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`;
  }
}
