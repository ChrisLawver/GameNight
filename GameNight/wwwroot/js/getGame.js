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
    let userInput = document.getElementById('search').value;        // might be nodeValue
    const clientId = "3PWFEgwSVs";
    const url = `https://api.boardgameatlas.com/api/search?name=${userInput}&client_id=${clientId}`;
    console.log(url);
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
    results.forEach(result => {
        var name;
        name = result.name;
        console.log(name);
    });
}

//function testGame(results) {
//    //let name = results.games[0].name;
//    //console.log(name);

//    var name = [];
//    for (let index = 0; index < results.name.length; index++) {
//        name[index] = results.name[index].names;
//    }
//    console.log(name);
//}