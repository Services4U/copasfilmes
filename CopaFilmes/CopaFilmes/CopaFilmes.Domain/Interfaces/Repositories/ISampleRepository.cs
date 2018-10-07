using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces.Repositories
{
    public interface ISampleRepository
    {
        Sample GetById(int id);
        IEnumerable<Sample> GetAll();
        IEnumerable<Sample> GetAllByPage(ref Paginacao paginacao);
        int Insert(Sample entity);
        bool Update(Sample entity);
        bool Delete(int id);
    }
}
