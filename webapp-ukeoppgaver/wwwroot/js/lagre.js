$(() => {
    hentPizzaer();
})

function hentPizzaer() {
    $.get("Holberg/hentPizza", (pizzaer) => {
        let ut = "<option>Velg merke</option>";
        for (const p of pizzaer) {
            ut += "<option id='" + p.id + "'>" + p.type + "</option>"
        }

        $("#type").html(ut);
    });
}

function lagreBestilling() {
    const bestilling = {
        pizza: {
            // TODO spør om det er noen måte å hente ID på, for å unngå å hente pizza fra DB for så å legge den inn | Tor sier nei, du må ha en pizza ut og feste til bestilling
            // id: null,
            // id: $("#type").attr('id'), // did not work, kept giving duplicate pizzas
            type: $("#type").val()
        },
        tykk: $("input:radio[name=tykkelse]:checked").val(), // 100% stole this from tor
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