document.addEventListener("DOMContentLoaded", function () {

    // Evento para los botones de inactivar
    document.querySelectorAll(".btn-outline-warning").forEach(button => {
        button.addEventListener("click", function (event) {
            event.preventDefault(); // Prevenir el enlace por defecto

            // Mostrar alerta de confirmación para inactivar
            Swal.fire({
                title: '¿Estás seguro?',
                text: '¿Quieres inactivar esta reseña?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#3085d6',
                confirmButtonText: 'Inactivar',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Si el usuario confirma, redirigir a la acción de inactivar
                    window.location.href = button.href; // Usar el enlace original del botón
                }
            });
        });
    });

    // Evento para los botones de activar
    document.querySelectorAll(".btn-outline-success").forEach(button => {
        button.addEventListener("click", function (event) {
            event.preventDefault(); // Prevenir el enlace por defecto

            // Mostrar alerta de confirmación para activar
            Swal.fire({
                title: '¿Estás seguro?',
                text: '¿Quieres activar esta reseña?',
                icon: 'info',
                showCancelButton: true,
                confirmButtonColor: '#28a745',
                cancelButtonColor: '#3085d6',
                confirmButtonText: 'Activar',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Si el usuario confirma, redirigir a la acción de activar
                    window.location.href = button.href; // Usar el enlace original del botón
                }
            });
        });
    });

    // Formulario de respuesta
    document.getElementById("miFormulario").addEventListener("submit", function (event) {
        event.preventDefault();

        let comentarios = document.getElementById("comentarios").value.trim();

        if (comentarios === "") {
            Swal.fire({
                title: "Campos incompletos",
                text: "Por favor, completa todos los campos obligatorios.",
                icon: "error"
            });
            return;
        }

        Swal.fire({
            title: "Respuesta agregada",
            text: "Su respuesta ha sido guardada correctamente.",
            icon: "success"
        }).then(() => {
            event.target.submit(); // Enviar el formulario si todo es correcto
        });
    });
});
