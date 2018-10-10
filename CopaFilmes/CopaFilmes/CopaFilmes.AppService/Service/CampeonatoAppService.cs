using AutoMapper;
using CopaFilmes.AppService.Interfaces;
using CopaFilmes.AppService.Validations;
using CopaFilmes.AppService.ViewModels;
using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Domain.Entities.Domain.CopaFilmes;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace CopaFilmes.AppService.Service
{
    public class CampeonatoAppService : ICampeonatoAppService
    {
        private readonly ICampeonatoService CampeonatoService;
        private readonly IMapper Mapper;
        private CampeonatoValidator validator;
        private ValidationResult result;

        public CampeonatoAppService(ICampeonatoService campeonatoService, IMapper mapper)
        {
            CampeonatoService = campeonatoService;
            Mapper = mapper;
        }

        public ClassificacaoVm ObterCampeao(IEnumerable<FilmeVm> filmes)
        {
            validator = new CampeonatoValidator();
            result = new ValidationResult();

            result = validator.Validate((List<FilmeVm>)filmes);

            if (result.IsValid)
                return Mapper.Map<ClassificacaoVm>(CampeonatoService.ObterCampeao(Mapper.Map<List<Filme>>(filmes)));
            else
                throw new Exception(result.Errors[0].ErrorMessage);            
        }
    }
}
