/* BEGIN EXTERNAL SOURCE */

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

    document.addEventListener("DOMContentLoaded", function () {
        // Convertimos los datos del servidor a JSON
        let v/*******************************************************/rMes));

        let meses =/*************************************************************/ventasPorMes.map(item => item.Toe/******************************************************************/').getContext('2d');

        const data = {
            labels: meses,
            datasets: [{
                label: 'Total de Ventas (?)',
                data: totalVentas,
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.6)',
                tension: 0.3,
                fill: false
            }]
        };

        const config = {
            type: 'line',
            data: data,
            options: {
                plugins: {
                    title: {
                        text: 'Ventas Totales por Mes',
                        display: true
                    }
                },
                scales: {
                    x: {
                        type: 'time',
                        time: {
                            unit: 'month'
                        },
                        title: {
                            display: true,
                            text: 'Mes'
                        }
                    },
                    y: {
                        beginAtZero: true,
                        title: {
                            display: true,
                            text: 'Total Ventas (?)'
                        }
                    }
                }
            }
        };

        new Chart(ctx, config);
    });

/* END EXTERNAL SOURCE */
