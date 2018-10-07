using CopaFilmes.AppService.Interfaces;
using CopaFilmes.AppService.Service;
using CopaFilmes.AppService.Validations;
using CopaFilmes.AppService.ViewModels;
using CopaFilmes.Domain.Interfaces.Repositories;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Domain.Services;
using CopaFilmes.Persistence.Connection;
using CopaFilmes.Persistence.Repositories;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CopaFilmes.Infrastructure.CrossCutting.IoC
{
    public class InjectorContainer
    {
        public IServiceCollection ObterScopo(IServiceCollection interfaceService)
        {
            #region AppService

            interfaceService.AddScoped(typeof(ISampleAppService), typeof(SampleAppService));
            interfaceService.AddScoped(typeof(ICampeonatoAppService), typeof(CampeonatoAppService));

            #endregion

            #region Service

            interfaceService.AddScoped(typeof(ISampleService), typeof(SampleService));
            interfaceService.AddScoped(typeof(ICampeonatoService), typeof(CampeonatoService));

            #endregion

            #region Repository

            interfaceService.AddScoped(typeof(ISampleRepository), typeof(SampleRepository));
            interfaceService.AddScoped(typeof(IConnectionDB), typeof(ConnectionDB));
            
            #endregion

            return interfaceService;
        }
    }
}
