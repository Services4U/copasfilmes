using CopaFilmes.AppService.ViewModels;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using System.Collections.Generic;

namespace CopaFilmes.AppService.Interfaces
{
    public interface ISampleAppService
    {
        SampleVm ObterPorId(int id);
        IEnumerable<SampleVm> ObterTodos();
        IEnumerable<SampleVm> ObterTodosPorPaginacao(ref Paginacao paginacao);
        string Cadastrar(SampleVm sample);
        string Atualizar(SampleVm sample);
        bool Remover(int id);
    }
}
