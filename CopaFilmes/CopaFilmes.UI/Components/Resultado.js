Vue.component('ResultadoComponent', {
    template: `<main role="main" style="background-color:darkgray !important; color:white !important">

    <div class="jumbotron" style="background-color: dimgray !important; color: white !important; text-align:center; margin-top: 10px !important; margin-bottom: 80px !important" >
    <div class="container">
        <h6>CAMPEONATO DE FILMES</h6>
        <h2>Resultado Final</h2>
        <br />
        <br />
        <span>Veja o resultado final do Campeonato de filmes de forma simples e rápida</span>
    </div>
    </div>

    <hr>
        <div class="row">
            <div class="col-md-12" style="color: darkslategray !important; padding-bottom: 5px !important; padding-left: 5px !important">
              <div style="background-color: white !important; ">
                <div class="card mb-4 shadow-sm">
                    <div class="card-header">
                        <span>{{ pposicao }}</span>
                    </div>
                    <div class="card-body">
                        <h6 class="mb-0">
                            <span class="text-dark">{{ campeao }}</span>
                        </h6>
                    </div>
                </div>
                <div class="card mb-4 shadow-sm">
                    <div class="card-header">
                        <span>{{ sposicao }}</span>
                    </div>
                    <div class="card-body">
                        <h6 class="mb-0">
                            <span class="text-dark">{{ vice }}</span>
                        </h6>
                    </div>
                </div>
            </div>
        </div>
     </div>

    <hr>

    </div>

    </main>`,
    data: function () {
        return {
            pposicao: this.$route.query.pposicao,
            campeao: this.$route.query.campeao,
            sposicao: this.$route.query.sposicao,
            vice: this.$route.query.vice,
        }
    },
})