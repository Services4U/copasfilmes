Vue.component('FaseSelecaoComponent', {
    template: `<main role="main" style="background-color:darkgray !important; color:white !important">

        <div class="jumbotron" style="background-color: dimgray !important; color: white !important; text-align:center; margin-top: 10px !important; margin-bottom: 80px !important">
            <div class="container">
                <h6>CAMPEONATO DE FILMES</h6>
                <h2>Fase de Seleção</h2>
                <br />
                <br />
                <span>Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão Gerar Meu Campeonato para proseguir.</span>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-3">Selecionados {{contador}} de {{totalselecionado}} filmes</div>
                <div class="col-md-3"></div>
                <div class="col-md-3"></div>
                <div class="col-md-3"><a class="btn btn-secondary" href="#" role="button" v-on:click="gerarcampeonato">GERAR MEU CAMPEONATO</a></div>
            </div>
            <hr>
            <div class="row">
                <div class="col-md-3" v-for="filme in filmes" :key="filme.id" style="color: darkslategray !important; padding-bottom: 5px !important; padding-left: 5px !important">
                    <div style="background-color: white !important; ">
                        <div class="card mb-4 shadow-sm">
                            <div class="card-header">
                                <input type="checkbox" v-model="seleciona.filmes" :value="filme" @click="check($event)">
                            </div>
                            <div class="card-body">
                                <h6 class="mb-0">
                                    <span class="text-dark">{{ filme.titulo }}</span>
                                </h6>
                                <div class="mb-1 text-muted">{{ filme.ano }}</div>
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
            filmes: null,
            seleciona: {
                filmes: []
            },
            contador: 0,
            totalselecionado: 8,
            FilmesSelecionados: []
        }
    },
    mounted: function () {
        axios
            .get('http://copafilmes.azurewebsites.net/api/filmes')
            .then(response => {
                this.filmes = response.data
            })
            .catch(error => {
                console.log(error)
                this.errored = true
            })
    },
    methods: {
        check: function (e) {
            if (e.target.checked) {
                this.contador = this.contador + 1;
            }
        },
        gerarcampeonato: function (event) {

            if (this.contador < this.totalselecionado || this.contador > this.totalselecionado) {
                $("#msg").html('Obrigatório selecionar 8 filmes.');
                $("#modalMsg").modal();
            }
            else {

                var data = {
                    FilmesSelecionados: this.seleciona.filmes
                }

                axios.post('http://localhost:10738/campeonato/gerarmeucampeonato',
                    data, {
                        headers: {
                            responseType: 'json'
                        }
                    })
                    .then(response => {
                        $("#primeiroLugar").html('1o. Lugar ' + response.data.resultado.filmesVencedores[0].titulo + '<br/>');
                        $("#segundoLugar").html('2o. Lugar ' + response.data.resultado.filmesVencedores[1].titulo);
                        $("#modalVencedores").modal();
                    })
                    .catch(error => {
                        console.log(error)
                        this.errored = true
                    })
            }
        }
    }
})

