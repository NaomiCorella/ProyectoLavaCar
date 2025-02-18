document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("miFormulario").addEventListener("submit", function (event) {
        event.preventDefault(); 

        let comentarios = document.getElementById("comentarios").value.trim();
        let calificacion = document.getElementById("calificacion").value.trim();

 
        if (comentarios === "" && calificacion === "") {
            Swal.fire({
                title: "Campos incompletos",
                text: "Por favor, completa todos los campos obligatorios.",
                icon: "error"
            });
            return; 
        }

     
        Swal.fire({
            title: "Respuesta agregado",
            text: "Su respuesta ha sido guardara correctamente.",
            icon: "success"
        }).then(() => {
            event.target.submit(); 
        });
    });
});


