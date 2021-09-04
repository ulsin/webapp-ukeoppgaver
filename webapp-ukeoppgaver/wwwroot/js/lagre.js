function lagreBestilling() {
    const bestilling = {
        type: $("#type").val(),
        // tykk: $("#tykk").val(), //supposed to be like this
        tykk: true, // just for a moment pls no kill
        antall: $("#antall").val(),
        navn: $("#navn").val(),
        adresse: $("#adresse").val(),
        tlfNr: $("#tlfNr").val()
    }
    $.post("Holberg/lagre", bestilling, (OK) => {
        if (OK) {
            window.location.href = "index.html";
        } else {
            $("#feil").html("Feil hos server");
        }
    });
};