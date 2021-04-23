
let gameTitleDescription = document.getElementById('description');
let searchTerm = gameTitleDescription.innerText;

//event.preventDefault();

console.log(searchTerm);

const clientId = "3PWFEgwSVs";
const url = `https://api.boardgameatlas.com/api/search?name=${searchTerm}&client_id=${clientId}`;
fetch(url)
    .then(response => response.json())
    .then(data => {
        console.log(data);
        gameAttributes(data);
    })
    .catch(err => console.log(err));

function gameAttributes(data) {
    let description = data.games[0].description;
    ShowResults(description);
    console.log(description);
}

function ShowResults(description) {
    gameTitleDescription.innerHTML = description;
}