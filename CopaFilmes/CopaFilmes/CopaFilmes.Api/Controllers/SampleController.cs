using CopaFilmes.Api.Attributes;
using CopaFilmes.AppService.Interfaces;
using CopaFilmes.AppService.ViewModels;
using CopaFilmes.Infrastructure.CrossCutting.Enums;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopaFilmes.Api.Controllers
{
    [Route("exemplo")]
    [ApiController]
    //[Authorize] //Descomentar para solicitar autenticacao do metodo informando o token no header da requisicao
    public class SampleController : ControllerBase
    {
        private readonly ISampleAppService AppService;

        public SampleController(ISampleAppService appService)
        {
            AppService = appService;
        }

        [HttpGet]
        [Route("obter")]
        public ResultadoPesquisa<SampleVm> ObterPorId(int id) =>
            new ResultadoPesquisa<SampleVm>() { Resultado = AppService.ObterPorId(id) };

        [HttpGet]
        [Route("obter-todos")]
        public ResultadoPesquisa<IEnumerable<SampleVm>> ObterTodos() =>
             new ResultadoPesquisa<IEnumerable<SampleVm>>() { Resultado = AppService.ObterTodos() };

        [HttpGet]
        [Route("obter-todos-por-paginacao")]
        public ResultadoPesquisa<IEnumerable<SampleVm>> ObterTodosPorPaginacao(int numeroPagina, int quantidadeRegistros)
        {
            Paginacao paginacao = new Paginacao();
            paginacao.PaginaAtual = numeroPagina;
            paginacao.TamanhoPagina = quantidadeRegistros;
                       
            var samples = AppService.ObterTodosPorPaginacao(ref paginacao);
            
            return new ResultadoPesquisa<IEnumerable<SampleVm>>(samples, paginacao);
        }

        [HttpPost]
        [Route("cadastrar")]
        public ResultadoOperacao Cadastrar(SampleVm sample) =>
            new ResultadoOperacao() { Identificador = AppService.Cadastrar(sample).ToString(), Sucesso = true };

        [HttpPut]
        [Route("atualizar")]
        public ResultadoOperacao Atualizar(SampleVm sample)
        {
            var result = AppService.Atualizar(sample);

            return new ResultadoOperacao() { Identificador = sample.IdSample.ToString(), Sucesso = (result == "true" ? true : false) };
        }

        [HttpPut]
        [Route("remover")]
        public ResultadoOperacao Remover(int id)
        {
            bool resultado = false;

            resultado = AppService.Remover(id);

            return new ResultadoOperacao() { Identificador = id.ToString(), Sucesso = resultado };
        }
    }
}