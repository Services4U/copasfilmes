using AutoMapper;
using CopaFilmes.AppService.ViewModels;
using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Domain.Entities.Domain.CopaFilmes;

namespace CopaFilmes.AppService.ObjectMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Dominio para ViewModel

            CreateMap<Sample, SampleVm>();
            CreateMap<Filme, FilmeVm>();
            CreateMap<Classificacao, ClassificacaoVm>();

            #endregion

            #region ViewModel para Dominio

            CreateMap<SampleVm, Sample>();
            CreateMap<FilmeVm, Filme>();
            CreateMap<ClassificacaoVm, Classificacao>();

            #endregion
        }
    }
}
