using AutoMapper;
using CopaFilmes.AppService.Interfaces;
using CopaFilmes.AppService.Validations;
using CopaFilmes.AppService.ViewModels;
using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using System;
using System.Collections.Generic;

namespace CopaFilmes.AppService.Service
{
    public class SampleAppService : ISampleAppService
    {
        private readonly ISampleService SampleService;
        private readonly IMapper Mapper;
        private SampleValidator validator;

        public SampleAppService(ISampleService sampleService, IMapper mapper)
        {
            SampleService = sampleService;
            Mapper = mapper;
        }

        public SampleVm ObterPorId(int id) =>
            Mapper.Map<SampleVm>(SampleService.ObterPorId(id));
            
        public IEnumerable<SampleVm> ObterTodos() =>
            Mapper.Map<IEnumerable<SampleVm>>(SampleService.ObterTodos());

        public IEnumerable<SampleVm> ObterTodosPorPaginacao(ref Paginacao paginacao) =>
            Mapper.Map<IEnumerable<SampleVm>>(SampleService.ObterTodosPorPaginacao(ref paginacao));

        public string Cadastrar(SampleVm sample)
        {
            //Validacao com Fluent Validation
            var result = validator.Validate(sample);

            if (result.IsValid)
                return SampleService.Cadastrar(Mapper.Map<Sample>(sample)).ToString();
            else
                return result.Errors[0].ErrorMessage;
        }

        public string Atualizar(SampleVm sample)
        {
            //Validacao com Fluent Validation
            var result = validator.Validate(sample);

            if (result.IsValid)
                return SampleService.Atualizar(Mapper.Map<Sample>(sample)).ToString();
            else
                return result.Errors[0].ErrorMessage;
        }

        public bool Remover(int id) =>
            SampleService.Remover(id);
    }
}
