using CopaFilmes.AppService.ViewModels;
using FluentValidation;

namespace CopaFilmes.AppService.Validations
{
    public class SampleValidator : AbstractValidator<SampleVm>
    {
        public SampleValidator() =>
            //Fluent Validation
            RuleFor(x => x.Name).NotNull();
    }
}
