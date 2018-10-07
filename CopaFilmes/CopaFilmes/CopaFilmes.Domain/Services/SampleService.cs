using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Domain.Interfaces.Repositories;
using CopaFilmes.Domain.Interfaces.Services;
using CopaFilmes.Infrastructure.CrossCutting.Utilities;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace CopaFilmes.Domain.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository SampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            SampleRepository = sampleRepository;
        }

        public Sample ObterPorId(int id) 
        {
            //Regras de negócio aqui
            return SampleRepository.GetById(id);
        }

        public IEnumerable<Sample> ObterTodos()
        {
            //Regras de negócio aqui
            return SampleRepository.GetAll();
        }

        public IEnumerable<Sample> ObterTodosPorPaginacao(ref Paginacao paginacao)
        {
            //Regras de negócio aqui
            return SampleRepository.GetAllByPage(ref paginacao);
        }

        public int Cadastrar(Sample sample)
        {
            //Regras de negócio aqui
            using (var scope = new TransactionScope()) {
                int identificador = 0;

                identificador = SampleRepository.Insert(sample);

                scope.Complete();

                return identificador;
            }
        }

        public bool Atualizar(Sample sample)
        {
            //Regras de negócio aqui
            using (var scope = new TransactionScope()) {
                bool efetivado = false;

                efetivado = SampleRepository.Update(sample);

                scope.Complete();

                return efetivado;
            }
        }

        public bool Remover(int id)
        {
            //Regras de negócio aqui
            using (var scope = new TransactionScope()) {
                bool efetivado = false;

                efetivado = SampleRepository.Delete(id);

                scope.Complete();

                return efetivado;
            }
        }
    }
}
