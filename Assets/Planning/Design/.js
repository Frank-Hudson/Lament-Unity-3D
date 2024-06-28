const query = new URLSearchParams(window.location.search);
const screen = query.get("s");

console.debug(screen);

const screenElement = document.getElementById("screen");
