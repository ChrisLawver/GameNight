﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
        var name = result.name;
        var gameImg = result.images.small;
        var gameId = result.id;
        var minPlayers = result.min_players;
        var maxPlayers = result.max_players;
        ShowResults(name, gameImg, gameId, minPlayers, maxPlayers);
    });
}

function ShowResults(name, gameImg, gameId, minPlayers, maxPlayers) {
    let link = document.createElement("a");
    link.href = `/Game/CheckGame?externalId=${gameId}&name=${name}&image=${gameImg}&minPlayers=${minPlayers}&maxPlayers=${maxPlayers}`;
    let searchResult = document.createElement("h3");
    let searchResultImg = document.createElement("img");
    searchResultImg.classList.add("gameGalleryImage");
    searchResult.classList.add("gameList");
    searchResult.innerHTML = `Add <strong>${name}</strong> to Gallery`;
    searchResultImg.src = gameImg;
    link.appendChild(searchResult);
    link.appendChild(searchResultImg);
    resultDisplay.appendChild(link);
}

