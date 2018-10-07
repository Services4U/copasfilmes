using CopaFilmes.AppService.Validations;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.AppService.ViewModels
{
    //Fluent Validation para validacoes complexas
    public class SampleVm
    {
        [Required] //Data Annotations para validacoes simples
        public int IdSample { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
