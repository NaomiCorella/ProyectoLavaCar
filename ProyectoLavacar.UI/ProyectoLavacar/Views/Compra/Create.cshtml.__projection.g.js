/* BEGIN EXTERNAL SOURCE */

        $(document).ready(function () {
            $("#buscarCliente").click(function () {
                var cedula = $("#numeroCedula").val();
                if (cedula === "") {
                    alert("Por favor, ingrese una cédula.");
                    return;
                }

                $.ajax({
                    url: '/*********************************************/',
                    type: 'GET',
                    data: { numeroCedula: cedula },
                    success: function (response) {
                        if (response.success) {
                            $("#nombreCliente").text("Cliente encontrado: " + response.nombre + " " + response.apellido).show();
                        } else {
                            $("#nombreCliente").text("No se encontró un cliente con esa cédula.").show();
                        }
                    },
                    error: function () {
                        alert("Ocurrió un error al buscar el cliente.");
                    }
                });
            });

            function calcularTotal() {
                var total = 0;

                $("input[name='listaServicios']:checked").each(function () {
                    var servicioId = $(this).val();

                    $.ajax({
                        url: '/********************************************/',
                        type: 'GET',
                        data: { idServicio: servicioId },
                        success: function (response) {
                            if (response.success) {
                                total += parseFloat(response.precio);
                            }
                            $("#Total").val(total.toFixed(2));
                        },
                        error: function () {
                            alert("Ocurrió un error al obtener el precio del servicio.");
                        }
                    });
                });
            }

            $("input[name='listaServicios']").change(function () {
                calcularTotal();
            });

            calcularTotal();
        });
        
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
