$(() => {
    hentAlleKunder();
});

function hentAlleKunder() {
    $.get("Holberg/hentAlle", (bestillinger) => {
        formaterAlleKunder(bestillinger);
        }
    );
}

function formaterAlleKunder(kunder) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>Navn</th>" +
        "<th>Adresse</th>" +
        "<th></th>" +
        "<th></th>" +
        "</tr>";
    for (let k of kunder) {
        ut += "<tr>" +
            "<td>" + k.navn + "</td>" +
            "<td>" + k.adresse + "</td>" +
            "<td><a class='btn btn-primary' href='endre.html?id=" + k.id + "'>Endre</a></td>" +
            "<td><a class='btn btn-danger' onclick='slettKunde(" + k.id + ")'>Slett</a></td>" +
            "</tr>";
    }
    ut += "</table>"
    $("#inDiv").html(ut);
}

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