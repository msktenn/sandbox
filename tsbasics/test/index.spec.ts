import { introduceMyself } from "../src/index";

describe("Configuratio", () => {
  it("should be as singleton", () => {
    console.log("test");
    expect(introduceMyself("J", "H")).toEqual("Hello J H");
  });
});
