using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Domain.Entities.Domain.CopaFilmes;
using CopaFilmes.Infrastructure.CrossCutting.Utilities;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using System;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Services
{
    public interface ICampeonatoService
    {
        Classificacao ObterCampeao(IEnumerable<Filme> filmes);
    }
}
