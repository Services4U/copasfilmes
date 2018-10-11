using AutoMapper;
using CopaFilmes.Api.Controllers;
using CopaFilmes.AppService.Interfaces;
using CopaFilmes.AppService.Service;
using CopaFilmes.AppService.ViewModels;
using CopaFilmes.Domain.Entities.Domain.CopaFilmes;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Domain.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CopaFilmes.Test
{
    public class CampeonatoTest
    {
        private ICampeonatoService service;

        public CampeonatoTest()
        {
            service = new CampeonatoService();
        }
        
        [Fact]
        public void Obter_Campeao_Nao_Nulo()
        {
            List<Filme> filmes = new List<Filme>();
            filmes.Add(new Filme { Id = "1", Ano = 1980, Nota = 4, Titulo = "Teste1" });
            filmes.Add(new Filme { Id = "2", Ano = 1984, Nota = 2, Titulo = "Teste2" });
            filmes.Add(new Filme { Id = "3", Ano = 1970, Nota = 1, Titulo = "Teste3" });
            filmes.Add(new Filme { Id = "4", Ano = 1999, Nota = 5, Titulo = "Teste4" });
            filmes.Add(new Filme { Id = "5", Ano = 1984, Nota = 3, Titulo = "Teste5" });
            filmes.Add(new Filme { Id = "6", Ano = 1988, Nota = 4, Titulo = "Teste6" });
            filmes.Add(new Filme { Id = "7", Ano = 1990, Nota = 1, Titulo = "Teste7" });
            filmes.Add(new Filme { Id = "8", Ano = 2000, Nota = 2, Titulo = "Teste8" });
            
            var campeao = service.ObterCampeao(filmes);

            Assert.NotNull(campeao.FilmesVencedores);
        }

        [Fact]
        public void Obter_Campeao_Informando_8_filmes()
        {
            List<Filme> filmes = new List<Filme>();
            filmes.Add(new Filme { Id = "1", Ano = 1980, Nota = 4, Titulo = "Teste1" });
            filmes.Add(new Filme { Id = "2", Ano = 1984, Nota = 2, Titulo = "Teste2" });
            filmes.Add(new Filme { Id = "3", Ano = 1970, Nota = 1, Titulo = "Teste3" });
            filmes.Add(new Filme { Id = "4", Ano = 1999, Nota = 5, Titulo = "Teste4" });
            filmes.Add(new Filme { Id = "5", Ano = 1984, Nota = 3, Titulo = "Teste5" });
            filmes.Add(new Filme { Id = "6", Ano = 1988, Nota = 4, Titulo = "Teste6" });
            filmes.Add(new Filme { Id = "7", Ano = 1990, Nota = 1, Titulo = "Teste7" });
            filmes.Add(new Filme { Id = "8", Ano = 2000, Nota = 2, Titulo = "Teste8" });

            var campeao = service.ObterCampeao(filmes);

            Assert.Equal(8, filmes.Count);
        }

        [Fact]
        public void Obter_Campeao_Retornando_2_vencedores()
        {
            List<Filme> filmes = new List<Filme>();
            filmes.Add(new Filme { Id = "1", Ano = 1980, Nota = 4, Titulo = "Teste1" });
            filmes.Add(new Filme { Id = "2", Ano = 1984, Nota = 2, Titulo = "Teste2" });
            filmes.Add(new Filme { Id = "3", Ano = 1970, Nota = 1, Titulo = "Teste3" });
            filmes.Add(new Filme { Id = "4", Ano = 1999, Nota = 5, Titulo = "Teste4" });
            filmes.Add(new Filme { Id = "5", Ano = 1984, Nota = 3, Titulo = "Teste5" });
            filmes.Add(new Filme { Id = "6", Ano = 1988, Nota = 4, Titulo = "Teste6" });
            filmes.Add(new Filme { Id = "7", Ano = 1990, Nota = 1, Titulo = "Teste7" });
            filmes.Add(new Filme { Id = "8", Ano = 2000, Nota = 2, Titulo = "Teste8" });

            var campeao = service.ObterCampeao(filmes);

            Assert.Equal(2, campeao.FilmesVencedores.Count);
        }
    }
}
