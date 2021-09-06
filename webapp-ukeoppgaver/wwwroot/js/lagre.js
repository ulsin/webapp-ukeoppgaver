// function hentPizzaer() {
//     .get
// }

function lagreBestilling() {
    const bestilling = {
        pizza: {
            // id: null,
            type: $("#type").val()
        },
        tykk: true, // untill i set up radio right
        antall: $("#antall").val(),
        kunde: {
            // id: null,
            navn: $("#navn").val(),
            adresse: $("#adresse").val(),
            tlfNr: $("#tlfNr").val()
        }
    }
    $.post("Holberg/lagre", bestilling, (OK) => {
        if (OK) {
            window.location.href = "index.html";
        } else {
            $("#feil").html("Feil hos server");
        }
    });
};