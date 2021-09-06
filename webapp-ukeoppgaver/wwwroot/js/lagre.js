$(() => {
    hentPizzaer();
})
/*TODO 
 * Fix Radio menu for choosing thick or not.*/

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