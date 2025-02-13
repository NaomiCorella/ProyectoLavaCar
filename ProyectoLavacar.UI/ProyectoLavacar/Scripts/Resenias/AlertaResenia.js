        document.addEventListener("DOMContentLoaded", function () {
            document.getElementById("miFormulario").addEventListener("submit", function (event) {
                event.preventDefault(); 

                //let idServicio = document.getElementById("idServicio").value.trim();
                let fecha = document.getElementById("fecha").value.trim();
                let calificacion = document.getElementById("calificacion").value.trim();
                let comentarios = document.getElementById("comentarios").value.trim();

                let camposVacios = [];

                //if (idServicio === "") camposVacios.push("Servicio");
                if (fecha === "") camposVacios.push("Fecha");
                if (calificacion === "") camposVacios.push("Calificación");
                if (comentarios === "") camposVacios.push("Comentarios");
                if (camposVacios.length > 0) {
                    Swal.fire({
                        title: "Campos incompletos",
                        text: "Por favor, completa los siguientes campos: " + camposVacios.join(", "),
                        icon: "error"
                    });
                }

                Swal.fire({
                    title: "Respuesta agregada",
                    text: "La reseña se envió correctamente.",
                    icon: "success"
                }).then(() => {
                    event.target.submit(); 
                });
            });
    });

