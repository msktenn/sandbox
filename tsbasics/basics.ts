let userName: string = "Mike";
let hasLoggedIn: boolean = true;
let myNumber: number = 10;
let myRegex: RegExp = /foo/;

userName += " Knight";

console.log(userName);

const names: string[] = userName.split(" ");

const myValues: Array<number> = [1, 2, 3];

interface Person {
  first: string;
  last: string;
}

const myPerson: Person = {
  first: "Mike",
  last: "Knight",
};

const ids: Record<number, string> = {
  10: "a",
  20: "b",
};
ids[30] = "c";

if (ids[30] === "D") {
}

for (let i = 0; i < 10; i++) {
  console.log(i);
}

[1, 2, 3].forEach((v) => console.log(v));

const out: number[] = [4, 5, 6].map((v) => v * 10);
