using CopaFilmes.AppService.ViewModels;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using System.Collections.Generic;

namespace CopaFilmes.AppService.Interfaces
{
    public interface ICampeonatoAppService
    {
        ClassificacaoVm ObterCampeao(IEnumerable<FilmeVm> filmes);
    }
}
