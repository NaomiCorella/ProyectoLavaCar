document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("miFormulario").addEventListener("submit", function (event) {
        event.preventDefault(); 

        let categoria = document.getElementById("categoria").value.trim();

        if (nombre === "" || categoria === "" || precio === "" || cantidad === "") {
            Swal.fire({
                title: "Campos incompletos",
                text: "Por favor, completa todos los campos obligatorios.",
                icon: "error"
            });
            return;
        }

        Swal.fire({
            title: "Producto Editado ",
            text: "El producto se ha editado exitosamente.",
            icon: "success"
        }).then(() => {
            event.target.submit();
        });
    });
});


