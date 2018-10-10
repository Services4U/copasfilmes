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
    [Route("campeonato")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonatoAppService AppService;

        public CampeonatoController(ICampeonatoAppService appService)
        {
            AppService = appService;
        }

        [HttpPost]
        [Route("gerarmeucampeonato")]
        public ResultadoPesquisa<ClassificacaoVm> ObterCampeao(FilmesData filmesData) =>
            new ResultadoPesquisa<ClassificacaoVm>() { Resultado = AppService.ObterCampeao(filmesData.FilmesSelecionados) };
    }
}
