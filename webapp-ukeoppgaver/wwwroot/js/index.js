$(() => {
    hentAlleBestillinger();
});

function hentAlleBestillinger() {
    $.get("Holberg/hentAlle", (bestillinger) => {
        formaterAlleBestillinger(bestillinger);
        }
    );
}

function formaterAlleBestillinger(bestillinger) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Pizza Type</th>" +
        "<th>Tykkelse</th>" +
        "<th>Antall</th>" +
        "<th>Navn</th>" +
        "<th>Adresse</th>" +
        "<th>Telefon Nr</th>" +
        "</tr>";
    for (let b of bestillinger) {

        // used this i dunno : https://hackernoon.com/accessing-nested-objects-in-javascript-f02f1bd6387f
        // Didn't really use this but good to have: https://stackoverflow.com/questions/2098276/nested-json-objects-do-i-have-to-use-arrays-for-everything
        const type = b && b.pizza ? b.pizza.type : null;
        const navn = b && b.kunde ? b.kunde.navn : null;
        const adresse = b && b.kunde ? b.kunde.adresse : null;
        const tlfNr = b && b.kunde ? b.kunde.tlfNr : null;
        
        ut += "<tr>" +
            // user && user.personalInfo ? user.personalInfo.name : null
            // "<td>" + b.pizza.type + "</td>" + // kan man ha nested objects i JSON?
            // "<td>" + b && b.pizza ? b.pizza.type : null + "</td>" + // kan man ha nested objects i JSON?
            "<td>" + type + "</td>" +
            "<td>" + (b.tykk ? "Tykk" : "Tynn") + "</td>" + // tester fordi jeg dum og bruker bool i type erklæring
            "<td>" + b.antall + "</td>" +
            "<td>" + navn + "</td>" +
            "<td>" + adresse + "</td>" +
            "<td>" + tlfNr + "</td>" +
            "</tr>";
    }
    ut += "</table>"
    $("#inDiv").html(ut);
}

// Woop også bare liftet fra ukesoppgaver vet ikke om kommer til å brukes
function slettKunde(id) {
    const url = "Kunde/Slett?id=" + id;
    $.get(url, (OK) => {
        if (OK) {
            window.location.href = "index.html";
        } else {
            $("#feil").html("Feil hos server");
        }
    });
}