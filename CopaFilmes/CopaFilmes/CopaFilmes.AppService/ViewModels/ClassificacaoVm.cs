using CopaFilmes.AppService.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.AppService.ViewModels
{
    public class ClassificacaoVm
    {
        public IEnumerable<FilmeVm> FilmesVencedores { get; set; }
    }
}
