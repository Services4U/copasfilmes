const FaseSelecaoComponent = { template: '<FaseSelecaoComponent></FaseSelecaoComponent>' }
const ResultadoComponent = { template: '<ResultadoComponent></ResultadoComponent>' }

const routes = [
    { path: '/faseselecao', component: FaseSelecaoComponent },
    { path: '/resultado', component: ResultadoComponent },
    { path: '*', redirect: '/faseselecao' }
]

const router = new VueRouter({
    routes
})

var app = new Vue({
    router
}).$mount('#app')
