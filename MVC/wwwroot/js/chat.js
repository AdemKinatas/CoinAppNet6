"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/coinHub").build();


connection.on("ReceiveCoin", function (id, coinName, coinIcon, currentPrice, rateOfChange) {
    var tr = `    
            <tr>
                <td>
                    <img src=${coinIcon} width="35" height="35" />
                </td>
                <td>${coinName}</td>
                <td>${currentPrice}</td>
                <td>${rateOfChange}</td>
            </tr>`
    var tbody = document.getElementById('tbody')

    tbody.innerHTML += tr;
});

connection.start().then(function () {

    getData()

}).catch(function (err) {
    return console.error(err.toString());
});


function getData() {
    var tbody = document.getElementById('tbody')
    tbody.innerHTML = "";

    fetch("https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false")
        .then((response) => response.json())
        .then((data) => {
            data.forEach(function (coin) {
                connection.invoke("SendCoin", coin.id, coin.name, coin.image, coin.current_price, coin.price_change_percentage_24h).catch(function (err) {
                    return console.error(err.toString());
                });
            });
        });
}

setInterval(function () {
    getData()
}, 30000)
