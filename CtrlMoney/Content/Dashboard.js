(function($){
    $GeraGraficoDoughnut = function (options) {
        var entrou = true;
       // var idGrafico = document.getElementById("visao-geral-chart"); //ID Grafico, melhorar isso
        var myChart = new Chart(options.id, {
            type: 'doughnut',
            data: {
                labels: options.labels/*["Receitas", "Despesas", "Caixa"]*/,
                datasets: [{
                    data: options.data/*[2800, 1920, 880]*/,
                    backgroundColor: options.colors/*[ 
                        'rgba(18,187,173, 1)',
                        'rgba(220,53,69, 1)',
                        'rgba(79,112,206, 1)'
                    ]*/
                }]
            },
            options: {
                legend: {
                    display: false
                }
            }
        });
    };

    $GeraGraficoBar = function (options) {
        new Chart(options.id, {
            type: "bar",
            data: {
                labels: options.labels,// ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho"],
                datasets: [options.datasets/*{
                    "label": "Receitas",
                    "data": [2800, 1880, 2555, 2555, 2405, 2355, 2360],
                    "fill": false,
                    "backgroundColor": 'rgba(18,187,173, 1)'
                }, {
                    "label": "Despesas",
                    "data": [1920, 1875, 2000, 2150, 2050, 1995, 1895],
                    "fill": false,
                    "backgroundColor": 'rgba(220,53,69, 1)',
                }*/
                ]
            }, options: { scales: { yAxes: [{ ticks: { beginAtZero: true } }] } }
        });

    }

})(jQuery);
