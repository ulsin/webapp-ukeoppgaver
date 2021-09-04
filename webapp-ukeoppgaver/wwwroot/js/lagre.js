function lagreBestilling() {
    const kunde = {
        navn: $("#navn").val(),
        adresse: $("#adresse").val()
    }
    $.post("Kunde/lagre", kunde, (OK) => {
        if (OK) {
            window.location.href = "index.html";
        } else {
            $("#feil").html("Feil hos server");
        }
    });
};