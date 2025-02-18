$(document).ready(function () {
    $("#btnGuardar").click(function () {
        Swal.fire({
            title: "¿Guardar cambios?",
            text: "Se guardarán los cambios en la reserva.",
            icon: "question",
            showCancelButton: true,
            confirmButtonText: "Sí, guardar",
            cancelButtonText: "Cancelar"
        }).then((result) => {
            if (result.isConfirmed) {
                $("#formEditarReserva").submit(); 
            }
        });
    });
});