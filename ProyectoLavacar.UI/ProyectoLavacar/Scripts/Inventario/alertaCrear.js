document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("miFormulario").addEventListener("submit", function (event) {
        event.preventDefault(); 


        let nombre = document.getElementById("nombre").value.trim();
        let categoria = document.getElementById("categoria").value.trim();
        let precio = document.getElementById("precioUnitario").value.trim();
        let cantidad = document.getElementById("cantidadDisponible").value.trim();

       
        if (nombre === "" || categoria === "" || precio === "" || cantidad === "") {
            Swal.fire({
                title: "Campos incompletos",
                text: "Por favor, completa todos los campos obligatorios.",
                icon: "error"
            });
            return; 
        }

        Swal.fire({
            title: "Producto agregado",
            text: "El producto se ha agregado exitosamente.",
            icon: "success"
        }).then(() => {
            event.target.submit(); 
        });
    });
});


