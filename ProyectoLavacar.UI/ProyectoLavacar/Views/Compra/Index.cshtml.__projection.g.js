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

        document.addEventListener("DOMContentLoaded", function () {
            let table = new DataTable('#myTable', {
                pageLength: 10,
                lengthMenu: [5, 10, 25, 50, 100],  // Opciones de cantidad de registros
                searching: false,  // Elimina la caja de búsqueda
                language: {
                    lengthMenu: 'Mostrar _MENU_ registros por página',
                    zeroRecords: 'No se encontraron registros',
                    info: 'Mostrando página _PAGE_ de _PAGES_',
                    infoEmpty: 'No hay registros disponibles',
                    infoFiltered: '(filtrado de _MAX_ registros en total)',
                    paginate: {
                        first: 'Primera',
                        previous: 'Anterior',
                        next: 'Siguiente',
                        last: 'Última'
                    }
                }
            });
        });

    
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

        // Agregar etiquetas para responsive
        $(document).ready(function () {
            $('.luxury-table-row td').each(function () {
                var header = $(this).parent().find('th').eq($(this).index()).text();
                $(this).attr('data-label', header);
            });
        });
    
/* END EXTERNAL SOURCE */
