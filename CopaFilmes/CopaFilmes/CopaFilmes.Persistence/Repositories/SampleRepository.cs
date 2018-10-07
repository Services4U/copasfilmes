using CopaFilmes.Domain.Entities.Domain;
using CopaFilmes.Domain.Interfaces.Repositories;
using CopaFilmes.Infrastructure.CrossCutting.Enums;
using CopaFilmes.Infrastructure.CrossCutting.Utilities;
using CopaFilmes.Infrastructure.CrossCutting.Utilities.Results;
using CopaFilmes.Persistence.Connection;
using Microsoft.Extensions.Options;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CopaFilmes.Persistence.Repositories
{
    public class SampleRepository : BaseConnection, ISampleRepository
    {
        private readonly IOptions<KeysConfig> ChaveConfiguracao;
        private DataBaseType DataBaseType;

        public SampleRepository(IConnectionDB connection, IOptions<KeysConfig> chaveConfiguracao) : base(connection)
        {
            ChaveConfiguracao = chaveConfiguracao;
            DataBaseType = (DataBaseType)Enum.Parse(typeof(DataBaseType), ChaveConfiguracao.Value.TypeDB, true);
        }

        public Sample GetById(int id)
        {
            const string query = @"SELECT * FROM Sample WHERE IdSample = @idSample AND Ativo = 1";

            return IDbConn.CommandQuery<Sample>(query, DataBaseType, new { idSample = id }).FirstOrDefault();
        }

        public IEnumerable<Sample> GetAll()
        {
            const string query = @"SELECT * FROM Sample WHERE Ativo = 1";

            return IDbConn.CommandQuery<Sample>(query, DataBaseType).ToList();
        }

        public IEnumerable<Sample> GetAllByPage(ref Paginacao paginacao)
        {
            const string query = @"SELECT * FROM Sample WHERE Ativo = 1 ORDER BY IdSample";

            var samples = IDbConn.CommandQuery<Sample>(query, DataBaseType).ToPagedList(paginacao.PaginaAtual, paginacao.TamanhoPagina);

            paginacao.TotalRegistros = samples.TotalItemCount;
            paginacao.PaginaAtual = samples.PageNumber;
            paginacao.TamanhoPagina = samples.PageSize;
            paginacao.TotalPaginas = samples.PageCount;
            paginacao.PrimeiraPagina = samples.PageNumber == 1;
            paginacao.UltimaPagina = samples.PageNumber == samples.PageCount;

            return samples;
        }

        //Para carregar mais de uma entidade
        public IEnumerable<SampleComposite> GetSampleCompositeDetail()
        {
            var query = @"SELECT sc.IdSampleComposite,
                                 sc.Name,
                                 sc.Description,
                                 sd.IdSampleDetail,
                                 sd.Name,
                                 sd.Description
                          FROM SampleComposite sc 
                          INNER JOIN SampleDetail sd ON sd.IdSampleComposite = sc.IdSampleComposite
                          WHERE sc.Ativo = 1
                          AND sd.Ativo = 1";

            var sampleDetails = new List<SampleDetail>();
            var idSampleComposite = 0;

            return IDbConn.CommandQuery<SampleComposite, SampleDetail, SampleComposite>(query,
                (sampleComposite, sampleDetail) => {

                    if (idSampleComposite != sampleComposite.IdSampleComposite) {
                        if (idSampleComposite > 0)
                            sampleComposite.SampleDetails = sampleDetails;

                        sampleDetails = new List<SampleDetail>();
                    }

                    idSampleComposite = sampleComposite.IdSampleComposite;
                    sampleDetails.Add(sampleDetail);

                    return sampleComposite;
                }, DataBaseType, splitOn: "IdSampleDetail").ToList();
            // Caso tenha parametro: 
            //}, DataBaseType, new { IdParametro = idParametro }, splitOn: "IdSampleDetail").ToList();
        }

        public int Insert(Sample entity)
        {
            const string query = @"INSERT INTO Sample (Name) VALUES (@name)";

            return (int)IDbConn.CommandInsert(query, DataBaseType, new { name = entity.Name });
        }

        public bool Update(Sample entity)
        {
            const string query = @"UPDATE Sample SET Name = @name WHERE IdSample = @idSample";

            IDbConn.CommandExecute(query, DataBaseType, new { name = entity.Name, idSample = entity.IdSample });

            return true;
        }

        public bool Delete(int id)
        {
            const string query = @"UPDATE Sample SET Ativo = 0, DataAtualizacao = GetDate() WHERE IdSample = @idSample";

            IDbConn.CommandExecute(query, DataBaseType, new { idSample = id });

            return true;
        }
    }
}
