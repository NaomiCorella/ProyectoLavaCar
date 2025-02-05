document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("miFormulario").addEventListener("submit", function (event) {
        event.preventDefault(); // Evita el envío inmediato del formulario

        // Obtener los valores de los campos
        let nombre = document.getElementById("nombre").value.trim();
        let categoria = document.getElementById("categoria").value.trim();
        let precio = document.getElementById("precioUnitario").value.trim();
        let cantidad = document.getElementById("cantidadDisponible").value.trim();

        // Verificar si algún campo está vacío
        if (nombre === "" || categoria === "" || precio === "" || cantidad === "") {
            Swal.fire({
                title: "Campos incompletos",
                text: "Por favor, completa todos los campos obligatorios.",
                icon: "error"
            });
            return; // Detiene la ejecución si hay campos vacíos
        }

        // Si los campos están llenos, mostrar alerta de éxito
        Swal.fire({
            title: "Producto agregado",
            text: "El producto se ha agregado exitosamente.",
            icon: "success"
        }).then(() => {
            event.target.submit(); // Envía el formulario después de la confirmación
        });
    });
});


