using System.Collections.Generic;

namespace CopaFilmes.Infrastructure.CrossCutting.Utilities.Results
{
    public class ResultadoPesquisa<T> : ResultadoBase
    {
        public ResultadoPesquisa()
        {
            Resultado = default(T);
            TotalPaginas = null;
            TotalRegistros = null;
            PrimeiraPagina = null;
            UltimaPagina = null;
            TamanhoPagina = null;
            PaginaAtual = null;
        }

        public ResultadoPesquisa(T data)
        {
            Resultado = data;
        }

        public ResultadoPesquisa(T item, Paginacao pag)
        {
            PaginaAtual = pag.PaginaAtual;
            TotalPaginas = pag.TotalPaginas;
            TotalRegistros = pag.TotalRegistros;
            PrimeiraPagina = pag.PrimeiraPagina;
            UltimaPagina = pag.UltimaPagina;
            TamanhoPagina = pag.TamanhoPagina;
            Resultado = item;
        }

        public T Resultado { get; set; }
        public int? PaginaAtual { get; set; }
        public int? TotalPaginas { get; set; }
        public int? TotalRegistros { get; set; }
        public bool? PrimeiraPagina { get; set; }
        public bool? UltimaPagina { get; set; }
        public int? TamanhoPagina { get; set; }
    }

    public class ResultadoPesquisa : ResultadoBase
    {
        public ResultadoPesquisa()
        {
            Excecao = new List<Excecao>();
        }
    }
}
