namespace CopaFilmes.Infrastructure.CrossCutting.Utilities.Results
{
    public class Paginacao
    {
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalRegistros { get; set; }
        public bool PrimeiraPagina { get; set; }
        public bool UltimaPagina { get; set; }
        public int TamanhoPagina { get; set; }
    }
}
