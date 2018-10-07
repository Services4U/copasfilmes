using CopaFilmes.Infrastructure.CrossCutting.Enums;
using CopaFilmes.Infrastructure.CrossCutting.Utilities;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CopaFilmes.Persistence.Connection
{
    public class ConnectionDB : IConnectionDB
    {
        private readonly IOptions<KeysConfig> ChaveConfiguracao;

        public IDbConnection IConn { get; private set; }

        public ConnectionDB(IOptions<KeysConfig> chaveConfiguracao)
        {
            ChaveConfiguracao = chaveConfiguracao;
        }

        private IDbConnection SelectConnection()
        {
            var typeDB = (DataBaseType)Enum.Parse(typeof(DataBaseType), ChaveConfiguracao.Value.TypeDB, true);

            switch (typeDB)
            {
                case DataBaseType.SqlServer:
                    return new SqlConnection(ChaveConfiguracao.Value.ConnectionDB);
                default:
                    return new SqlConnection(ChaveConfiguracao.Value.ConnectionDB);
            }
        }

        public IDbConnection OpenConnection()
        {
            IConn = SelectConnection();

            if (IConn != null && IConn.State != ConnectionState.Open) {
                IConn.Open();
            }

            return IConn;
        }

        public void CloseConnection()
        {
            if (IConn != null && IConn.State == ConnectionState.Open) {
                IConn.Close();
                IConn.Dispose();
            }
        }

        public void Dispose() =>
            CloseConnection();
    }
}
