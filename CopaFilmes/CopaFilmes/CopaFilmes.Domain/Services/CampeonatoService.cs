using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Domain.Entities.Domain.CopaFilmes;
using CopaFilmes.Domain.Interfaces.Repositories;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Infrastructure.CrossCutting.Utilities;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace CopaFilmes.Domain.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private Classificacao classificacaoGeral;
        private Classificacao classificacaoFase;
        private List<Grupo> grupos;
        private Grupo grupo;

        public CampeonatoService()
        {
            classificacaoGeral = new Classificacao();
            classificacaoFase = new Classificacao();
        }

        public Classificacao ObterCampeao(IEnumerable<Filme> filmes)
        {
            var listaFilmes = (List<Filme>)filmes;

            while (listaFilmes.Count > 2)
            {
                classificacaoGeral = GerarFaseCampeonato(listaFilmes, listaFilmes.Count);

                listaFilmes = classificacaoGeral.FilmesVencedores;
            }

            return classificacaoGeral;
        }

        public Classificacao GerarFaseCampeonato(List<Filme> filmes, int final)
        {
            filmes = filmes.OrderBy(x => x.Titulo).ToList();

            var grupos = FormarGrupos(filmes);

            classificacaoFase.FilmesVencedores = new List<Filme>();

            grupos.ForEach(grupo => {
                var vencedor = GerarPartida(grupo);

                classificacaoFase.FilmesVencedores.Add(vencedor);
                if (final == 2) {
                    grupo.Filmes.ForEach(segundoLugar => {
                        classificacaoFase.FilmesVencedores.Add(segundoLugar);
                    });
                }
            });
            
            return classificacaoFase;
        }

        public List<Grupo> FormarGrupos(List<Filme> filmes)
        {
            grupos = new List<Grupo>();

            while (filmes.Count > 0)
            {
                grupo = new Grupo();

                var primeiro = filmes.First();
                filmes.RemoveAt(0);
                var ultimo = filmes.Last();
                filmes.RemoveAt(filmes.Count - 1);

                grupo.Filmes = new List<Filme>();

                grupo.Filmes.Add(primeiro);
                grupo.Filmes.Add(ultimo);

                grupos.Add(grupo);
            }

            return grupos;
        }

        public Filme GerarPartida(Grupo grupo)
        {
            Filme filme = new Filme();

            if (grupo.Filmes.First().Nota > grupo.Filmes.Last().Nota)
            {
                filme = grupo.Filmes.First();
            }
            else if (grupo.Filmes.First().Nota < grupo.Filmes.Last().Nota)
            {
                filme = grupo.Filmes.Last();
            }
            else if (grupo.Filmes.First().Nota == grupo.Filmes.Last().Nota)
            {
                filme = grupo.Filmes.OrderBy(x => x.Titulo).First();
            }

            return filme;
        }
    }
}
