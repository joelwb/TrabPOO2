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

    $fn.GeraGraficoBar = function (options) {
        new Chart(this, {
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

/*
new Chart(document.getElementById("fluxo-caixa-barra"), {
    "type": "bar",
    "data": {
        "labels": ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho"],
        "datasets": [{
            "label": "Receitas",
            "data": [2800, 1880, 2555, 2555, 2405, 2355, 2360],
            "fill": false,
            "backgroundColor": 'rgba(18,187,173, 1)'
        }, {
            "label": "Despesas",
            "data": [1920, 1875, 2000, 2150, 2050, 1995, 1895],
            "fill": false,
            "backgroundColor": 'rgba(220,53,69, 1)',
        }, {
            "label": "Moradia",
            "data": [380, 423, 360, 430, 420, 383, 359],
            "fill": false,
            "backgroundColor": "rgba(255, 99, 132, 0.4)",
        }, {
            "label": "Alimentação",
            "data": [800, 830, 770, 850, 820, 750, 726],
            "fill": false,
            "backgroundColor": "rgba(255, 159, 64, 0.4)",
        }, {
            "label": "Educação",
            "data": [350, 350, 350, 350, 350, 350, 350],
            "fill": false,
            "backgroundColor": "rgba(255, 205, 86, 0.4)",
        }, {
            "label": "Educação",
            "data": [350, 350, 350, 350, 350, 350, 350],
            "fill": false,
            "backgroundColor": "rgba(75, 192, 192, 0.4)",
        }, {
            "label": "Transporte",
            "data": [80, 80, 80, 80, 80, 80, 80],
            "fill": false,
            "backgroundColor": "rgba(54, 162, 235, 0.4)",
        }, {
            "label": "Saude",
            "data": [30, 12, , 50, 80, 20, 30],
            "fill": false,
            "backgroundColor": "rgba(153, 102, 255, 0.4)",
        }, {
            "label": "Outros",
            "data": [100, 80, 140, 150, 100, 112, 100],
            "fill": false,
            "backgroundColor": "rgba(201, 203, 207, 0.4)",
        }, {
            "label": "Caixa",
            "data": [880, 5, 555, 405, 355, 360, 465],
            "fill": false,
            "backgroundColor": 'rgba(79,112,206, 1)',
        }
        ]
    }, "options": { "scales": { "yAxes": [{ "ticks": { "beginAtZero": true } }] } }
});

*/

/*
    new Chart(document.getElementById("previsao-line-chart"),{
      "type":"bar",
      "data":{
      	"labels":["Janeiro", "Fevereiro", "Março","Abril","Maio","Junho","Julho","Agosto","setembro","Outubro","Novembro","Dezembro"],
        "datasets":[
          {"label":"Receitas",
                  "data":[2800,1880,2555,2555,2405,2355,2360,,,,,],
                  "fill":false,
                  "backgroundColor":'rgba(18,187,173, 1)'
          },
          {"label":"Receitas Prevista",
                  "data":[,,,,,,,2465,2495,2692,2792,2890],
                  "fill":false,
                  "backgroundColor":'rgba(18,187,173, 0.3)',
          },
          {"label":"Despesas",
                  "data":[1920,1875,2000,2150,2050,1995,1895,,,,,],
                  "fill":false,
                  "backgroundColor":'rgba(220,53,69, 1)',
          },
          {"label":"Despesas Prevista",
                  "data":[,,,,,,,1970,1803,1900,1902,2300],
                  "fill":false,
                  "backgroundColor":'rgba(220,53,69, 0.3)',
          },
          {"label":"Caixa",
                  "data":[880,5,555,405,355,360,465,,,,,],
                  "fill":false,
                  "backgroundColor":'rgba(79,112,206, 1)',
          },
          {"label":"Caixa Previsto",
                  "data":[,,,,,,,495,692,792,890,590],
                  "fill":false,
                  "backgroundColor":'rgba(79,112,206, 0.3)',
          }
        ]
      },
        "options":{
          "scales":{
            "yAxes":[{
              "ticks":{
                "beginAtZero":true
              }
            }]
          }
         }
      }
    );
  */