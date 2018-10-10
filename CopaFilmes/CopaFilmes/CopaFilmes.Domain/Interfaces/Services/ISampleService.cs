using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Infrastructure.CrossCutting.Utilities;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using System;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface ISampleService
    {
        Sample ObterPorId(int id);
        IEnumerable<Sample> ObterTodos();
        IEnumerable<Sample> ObterTodosPorPaginacao(ref Paginacao paginacao);
        int Cadastrar(Sample sample);
        bool Atualizar(Sample sample);
        bool Remover(int id);
    }
}
