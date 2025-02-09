$(document).ready(function () {
    $(document).on("click", ".abrirModalMovimiento", function () {
  


        $.ajax({
            url: '/Inventario/RegistrarMovimiento',
            data: {  },
            type: 'GET',
            success: function (response) {
                $('#ModalDeMovimiento .modal-body').html(response);
                $('#ModalDeMovimiento').modal("show");
            },
            error: function (xhr, status, error) {
                alert("Hubo un error: " + error);
            }
        });
    });
});

