/** @type {import('tailwindcss').Config} */

const colors = require("tailwindcss/colors");

module.exports = {
  content: ["./src/**/*.{html,js}"],
  theme: {
    extend: {
      colors: {
        successLight: "#b9f6ca",
        success200: "#69f0ae",
        successMain: "#00e676",
        successDark: "#00c853",
      },
    },
  },
  plugins: [],
};
