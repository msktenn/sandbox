import { config } from "../src/util/config";

describe("Configuration", () => {
  it("Should pull log level from env file", () => {
    expect(config.LogLevel).toBe("DEBUG");
  });

  it("Should pull log format from env file", () => {
    expect(config.LogFormat).toBe("PRETTY");
  });

  it("Should allow me to reset the variables", () => {
    config.Reset({ LogLevel: "INFO", LogFormat: "JSON" });
    expect(config.LogLevel).toBe("INFO");
    expect(config.LogFormat).toBe("JSON");
  });

  it("Should allow me to reset one variables", () => {
    config.Reset({ LogLevel: "VERBOSE" });
    expect(config.LogLevel).toBe("VERBOSE");
    expect(config.LogFormat).toBe("JSON");
  });
});
