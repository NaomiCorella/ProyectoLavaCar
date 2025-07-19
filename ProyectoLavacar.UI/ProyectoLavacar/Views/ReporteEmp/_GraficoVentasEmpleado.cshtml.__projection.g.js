/* BEGIN EXTERNAL SOURCE */
function name13() {
cargarDatosPorMes()
}
/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

    document.addEventListener("DOMContentLoaded", function () {
        const ctx = document.getElementById('graficoVentas').getContext('2d');

        var fechas = /****************************/;
        var totalVentas = /*********************************/;
        var margenVentas = /**********************************/;

        var config = {
            type: 'bar',
            data: {
                labels: fechas,
                datasets: [
                    {
                        label: 'Total Ventas',
                        data: totalVentas,
                        backgroundColor: 'rgba(75, 192, 192, 0.5)',
                        borderColor: 'rgba(75, 192, 192, 1)',
                        borderWidth: 1
                    },
                    {
                        label: 'Margen de Ventas',
                        data: margenVentas,
                        backgroundColor: 'rgba(255, 99, 132, 0.2)',
                        borderColor: 'rgba(255, 99, 132, 1)',
                        borderWidth: 2,
                        fill: false,
                        type: 'line',
                        tension: 0.4
                    }
                ]
            },
            options: {
                plugins: {
                    title: {
                        display: true,
                        text: 'Ventas Totales y Margen por Mes'
                    }
                },
                responsive: true,
                maintainAspectRatio: false,
                scales: {
                    x: { stacked: true },
                    y: {
                        stacked: true,
                        ticks: { beginAtZero: true }
                    }
                }
            }
        };

        var chart = new Chart(ctx, config);

        window.cargarDatosPorMes = function () {
            var mes = document.getElementById('mes').value;

            $.ajax({
                url: '/******************************************/',
                type: 'GET',
                data: { mes: mes || null },
                success: function (data) {
                    chart.data.labels = data.fechas;
                    chart.data.datasets[0].data = data.totalVentas;
                    chart.data.datasets[1].data = data.margenVentas;
                    chart.update();
                },
                error: function (error) {
                    console.log("Error en la solicitud AJAX:", error);
                }
            });
        }
    });

/* END EXTERNAL SOURCE */
fico con los nuevos datos
                    chart.data.labels = data.fechas;
                    chart.data.datasets[0].data = data.totalVentas;
                    chart.data.datasets[1].data = data.margenVentas;
                    chart.update();
                },
                error: function (error) {
                    console.log("Error en la solicitud AJAX:", error);
                }
            });
        }
    });

/* END EXTERNAL SOURCE */
