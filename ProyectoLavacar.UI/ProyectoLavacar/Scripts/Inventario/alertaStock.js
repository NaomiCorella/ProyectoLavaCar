document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("miFormulario").addEventListener("submit", function (event) {
        event.preventDefault(); // Evita el envío inmediato del formulario

  

        // Si los campos están llenos, mostrar alerta de éxito
        Swal.fire({
            title: "Stock modificado",
            text: "El stock del producto se ha modificado",
            icon: "success"
        }).then(() => {
            event.target.submit(); // Envía el formulario después de la confirmación
        });
    });
});


