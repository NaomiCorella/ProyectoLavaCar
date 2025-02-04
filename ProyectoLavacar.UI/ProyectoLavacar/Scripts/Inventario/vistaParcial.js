$(document).ready(function () {
    $("#abrirModal").click(function () {
        $.ajax({
            url: '/Inventario/lista',  // Asegúrate de tener el prefijo '/' si no está en la misma ruta
            data: { id: 1 },  // El parámetro id se está enviando correctamente
            type: 'GET',
            success: function (response) {
                $('#myModal .modal-body').html(response);  // Aquí se asigna la respuesta al cuerpo del modal
                $('#myModal').modal("show");  // Mostramos el modal
            },
            error: function (xhr, status, error) {
                alert("Hubo un error: " + error);  // Mostramos el mensaje de error en caso de fallo
            }
        });
    });
});
