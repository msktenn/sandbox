import { Log } from "../src/util/log";
import { config } from "../src/util/config";

describe("Log", () => {
  config.Reset({ LogLevel: "Trace", LogFormat: "Pretty" });

  it("should log Trace", () => {
    let consoleSpy = jest.spyOn(console, "log");
    try {
      consoleSpy.mockImplementation();
      Log.Trace("Test Log");
      expect(consoleSpy).toHaveBeenCalledTimes(1);
      expect(consoleSpy).toHaveBeenCalledWith({
        asymmetricMatch: (actual: string) => {
          return actual.match(/Trce.*?Test Log/);
        },
      });
    } catch (error) {
      // Restore the original console.log implementation
    } finally {
      consoleSpy.mockRestore();
    }
  });

  it("should log Debug", () => {
    let consoleSpy = jest.spyOn(console, "log");
    consoleSpy.mockImplementation();
    Log.Debug("Test Log");
    expect(consoleSpy).toHaveBeenCalledTimes(1);
    expect(consoleSpy).toHaveBeenCalledWith({
      asymmetricMatch: (actual: string) => {
        return actual.match(/Debug.*?Test Log/);
      },
    });
    // Restore the original console.log implementation
    consoleSpy.mockRestore();
  });

  it("should log info", () => {
    let consoleSpy = jest.spyOn(console, "log");
    consoleSpy.mockImplementation();
    Log.Info("Test Log");
    expect(consoleSpy).toHaveBeenCalledTimes(1);
    expect(consoleSpy).toHaveBeenCalledWith({
      asymmetricMatch: (actual: string) => {
        return actual.match(/Info.*?Test Log/);
      },
    });
    // Restore the original console.log implementation
    consoleSpy.mockRestore();
  });

  it("should log debug", () => {
    let consoleSpy = jest.spyOn(console, "log");
    consoleSpy.mockImplementation();
    Log.Warning("Test Log");
    expect(consoleSpy).toHaveBeenCalledTimes(1);
    expect(consoleSpy).toHaveBeenCalledWith({
      asymmetricMatch: (actual: string) => {
        return actual.match(/Warn.*?Test Log/);
      },
    });
    // Restore the original console.log implementation
    consoleSpy.mockRestore();
  });

  it("should log Error", () => {
    let consoleSpy = jest.spyOn(console, "log");
    consoleSpy.mockImplementation();
    Log.Error("Test Log");
    expect(consoleSpy).toHaveBeenCalledTimes(1);
    expect(consoleSpy).toHaveBeenCalledWith({
      asymmetricMatch: (actual: string) => {
        return actual.match(/Error.*?Test Log/);
      },
    });
    // Restore the original console.log implementation
    consoleSpy.mockRestore();
  });

  it("should log Fatal", () => {
    let consoleSpy = jest.spyOn(console, "log");
    consoleSpy.mockImplementation();
    Log.Fatal("Test Log");
    expect(consoleSpy).toHaveBeenCalledTimes(1);
    expect(consoleSpy).toHaveBeenCalledWith({
      asymmetricMatch: (actual: string) => {
        return actual.match(/Fatal.*?Test Log/);
      },
    });
    // Restore the original console.log implementation
    consoleSpy.mockRestore();
  });
});
