using CopaFilmes.AppService.ViewModels;
using FluentValidation;
using System.Collections.Generic;

namespace CopaFilmes.AppService.Validations
{
    public class CampeonatoValidator : AbstractValidator<List<FilmeVm>>
    {
        public CampeonatoValidator()
        {
            //Fluent Validation
            RuleFor(x => x.Count).Equal(8).WithMessage("Obrigatório selecionar 8 filmes.");
        }
    }
}
