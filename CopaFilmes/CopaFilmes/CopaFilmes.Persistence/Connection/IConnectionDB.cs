using System;
using System.Data;

namespace CopaFilmes.Persistence.Connection
{
    public interface IConnectionDB : IDisposable
    {
        IDbConnection OpenConnection();
        void CloseConnection();
    }
}
