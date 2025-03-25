/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

    document.addEventListener("DOMContentLoaded", function () {
        // Datos para el gráfico de servicios por mes
        let meses = @Html.Raw(Json.Encode(serviciosPorMes.Select(m => m["Mes"])));
        let totales = @Html.Raw(Json.Encode(serviciosPorMes.Select(m => m["TotalServicios"])));

        let ctx = document.getElementById('graficoServicios').getContext('2d');
        new Chart(ctx, {
            type: 'bar',
            data: {
                labels: meses,
                datasets: [{
                    label: 'Servicios por Mes',
                    data: totales,
                    backgroundColor: 'rgba(75, 192, 192, 0.6)',
                    borderColor: 'rgba(75, 192, 192, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: { beginAtZero: true }
                }
            }
        });
    });

/* END EXTERNAL SOURCE */
