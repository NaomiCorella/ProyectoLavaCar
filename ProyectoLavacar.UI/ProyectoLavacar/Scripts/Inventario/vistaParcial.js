$(document).ready(function () {
    $(document).on("click", ".abrirModal", function () {
        var id = $(this).data('id');  // Obtener el id del producto

        console.log("ID seleccionado:", id);  // Debug en consola

        $.ajax({
            url: '/Inventario/lista',
            data: { id: id },
            type: 'GET',
            success: function (response) {
                $('#myModal .modal-body').html(response);
                $('#myModal').modal("show");
            },
            error: function (xhr, status, error) {
                alert("Hubo un error: " + error);
            }
        });
    });
});

