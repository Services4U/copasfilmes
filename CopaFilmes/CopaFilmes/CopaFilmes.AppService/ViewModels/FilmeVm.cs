using CopaFilmes.AppService.Validations;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.AppService.ViewModels
{
    public class FilmeVm
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public decimal Nota { get; set; }
    }
}
