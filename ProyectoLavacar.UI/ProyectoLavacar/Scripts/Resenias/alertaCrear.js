function mostrarAlerta() {
    let comentarios = document.getElementById("comentarios").value.trim();

    if (comentarios === "") {
        Swal.fire({
            title: "Campos incompletos",
            text: "Por favor, completa todos los campos obligatorios.",
            icon: "error"
        });

        event.preventDefault();  // Prevenir el envío del formulario si los comentarios están vacíos
    } else {
        Swal.fire({
            title: "Respuesta agregada",
            text: "Su respuesta ha sido guardada correctamente.",
            icon: "success"
        });
    }
}
