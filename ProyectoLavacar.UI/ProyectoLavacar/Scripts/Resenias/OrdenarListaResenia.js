document.addEventListener("DOMContentLoaded", function () {
    var urlParams = new URLSearchParams(window.location.search);
    var ordenarPor = urlParams.get("ordenarPor");
    var orden = urlParams.get("orden");

    if (ordenarPor) {
        document.getElementById("ordenarPor").value = ordenarPor;
    }

    if (orden) {
        document.getElementById("orden").value = orden;
    }
});