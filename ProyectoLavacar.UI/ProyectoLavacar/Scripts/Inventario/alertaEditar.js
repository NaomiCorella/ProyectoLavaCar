document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("miFormulario").addEventListener("submit", function (event) {
        event.preventDefault(); 

    

     
        Swal.fire({
            title: "Producto Editado ",
            text: "El producto se ha editado exitosamente.",
            icon: "success"
        }).then(() => {
            event.target.submit();
        });
    });
});


