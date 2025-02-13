$(document).ready(function () {
    $("#btnFiltrar").click(function () {
        let filtroUsuario = $("#filtroUsuario").val();
        let filtroContenido = $("#filtroContenido").val();
        let filtroFecha = $("#filtroFecha").val();

        let url = "/Resenia/IndexAdmin?filtroUsuario=" + encodeURIComponent(filtroUsuario) +
            "&filtroContenido=" + encodeURIComponent(filtroContenido) +
            "&filtroFecha=" + encodeURIComponent(filtroFecha);

        window.location.href = url;
    });

    $("#btnReset").click(function () {
        window.location.href = "/Resenia/IndexAdmin";
    });
});