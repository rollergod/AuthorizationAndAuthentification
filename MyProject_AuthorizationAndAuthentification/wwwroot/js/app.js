const icon = document.querySelector('.icon');
const search = document.querySelector('.search');
const clearBtn = document.querySelector('.clear');
const clear = document.getElementById('mysearch');


icon.onclick = function () {
    search.classList.toggle('active');
}


clearBtn.onclick = function () {
    clear.value = ''
}




// $('#list').click(function () {
//     var selectedValue = document.getElementById('list').value;
//     console.log(selectedValue);
// });

// function loadRankings() {
//     const request = new XMLHttpRequest();

//     request.open("get", "data/rankings.json");
//     request.onload = () => {
//         try {
//             const json = JSON.parse(request.responseText) //JSON
//             populateRankings(json);
//         } catch (error) {
//             console.warn("Could not load rankings table! ");
//         }
//     };

//     request.send();
// }


const tdElement = document.getElementById('td');

var selectedValue = "";
function getSelectedValue() {
    selectedValue = document.getElementById('list').value;
    tdElement.textContent = selectedValue;
}

const rankingsBody = document.querySelector("#rankings-table > tbody");

function populateRankings(json) {
    //Clears out existing table data
    while (rankingsBody.firstChild) {
        rankingsBody.removeChild(rankingsBody.firstChild);
    }

    for (const standing of json) {
        console.log(standing)
        const tr = document.createElement("tr");
        for (const st in standing) {
            if (st == 'team' || st == 'position' || st == 'points' || st == 'playedGames') {
                const td = document.createElement("td");
                if (st == 'team' && typeof standing[st] === 'object') {
                    var flagClass = getFlag();

                    td.innerHTML = "<span class=" + flagClass + "></span>" + standing[st].name;
                    console.log(st + ' ' + standing[st].name);
                }
                else if (st == 'position') {
                    td.textContent = standing[st]
                    setClassesForTable(selectedValue, standing, st, td);
                    console.log(st)
                }
                else if (st == 'points') {
                    td.textContent = standing[st]
                    console.log(st)
                }
                else if (st == 'playedGames') {
                    td.textContent = standing[st]
                    console.log(st)
                }
                tr.appendChild(td);
            }
        }

        rankingsBody.appendChild(tr);
    }
}



function getFlag() {
    if (selectedValue === 'PL')
        return 'icon-flag_1133'
    else if (selectedValue === 'SA')
        return 'icon-flag_24575'
    else if (selectedValue === 'BL')
        return 'icon-flag_2557'

    return '';
}

function setClassesForTable(selectedValue, standing, st, td) {

    switch (selectedValue) {
        case 'SA':

            if (standing[st] < 5)
                td.classList.add('championsleague');
            else if (standing[st] === 5 || standing[st] === 6)
                td.classList.add('euroleague');
            else if (standing[st] > 6 && standing[st] < 18)
                td.classList.add('middle');
            else
                td.classList.add('out');

            break;

        case 'PL':

            if (standing[st] < 5)
                td.classList.add('championsleague');
            else if (standing[st] === 5)
                td.classList.add('euroleague');
            else if (standing[st] > 5 && standing[st] < 18)
                td.classList.add('middle');
            else
                td.classList.add('out');

            break;

        case 'BL':

            if (standing[st] < 5)
                td.classList.add('championsleague');
            else if (standing[st] === 5 || standing[st] === 6)
                td.classList.add('euroleague');
            else if (standing[st] > 6 && standing[st] < 18)
                td.classList.add('middle');
            else
                td.classList.add('out');

            break;
    }

}

async function loadIntoTable() {
    var url = "";
    getSelectedValue();
    if (selectedValue === 'SA')
        url = "https://api.football-data.org/v2/competitions/SA/standings";
    else if (selectedValue === 'PL')
        url = "https://api.football-data.org/v2/competitions/PL/standings";
    else if (selectedValue === 'BL')
        url = "https://api.football-data.org/v2/competitions/BL1/standings";

    var test = "";

    const reseponse = await fetch(url, {
        method: 'GET',
        headers: {
            "X-Auth-Token": "b5c5e4998357484da72349f3c3b2940a",
        }
    }).then(resp => resp.json()).then(test => test["standings"]).then(standings => standings["0"].table).then(t => test = t);

    populateRankings(test);
}

document.addEventListener("DOMContentLoaded", loadIntoTable);