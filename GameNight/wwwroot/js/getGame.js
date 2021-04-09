// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// client_id: 3PWFEgwSVs
// client_secret: 607f375cb167d59aac0bbd028e8822bd
// redirect_uri: None Set

// const clientSecret = "607f375cb167d59aac0bbd028e8822bd";

let buttonSubmit = document.getElementById('gameSearch');

let resultDisplay = document.getElementById('gameResult');

buttonSubmit.addEventListener('click', function () {
    event.preventDefault();
    let userInput = document.getElementById('search').value;
    const clientId = "3PWFEgwSVs";
    const url = `https://api.boardgameatlas.com/api/search?name=${userInput}&client_id=${clientId}`;
    fetch(url)
        .then(response => response.json())
        .then(data => {
            console.log(data);
            gameAttributes(data);
        })
        .catch(err => console.log(err));
})

function gameAttributes(data) {
    let results = data.games;
    resultDisplay.innerHTML = "";
    results.forEach(result => {
        var name;
        var gameImg;
        var gameId = result.id;
        name = result.name;
        gameImg = result.images.small;
        ShowResults(name, gameImg, gameId);
    });
}

function ShowResults(name, gameImg, gameId) {

    let link = document.createElement("a");
    link.href = `/Game/CheckGame?externalId=${gameId}&name=${name}`;
    let searchResult = document.createElement("h3");
    let searchResultImg = document.createElement("img");
    searchResult.innerText = name;
    searchResultImg.src = gameImg;
    link.appendChild(searchResult);
    link.appendChild(searchResultImg);
    resultDisplay.appendChild(link);
}