using System.ComponentModel;

namespace CopaFilmes.Infrastructure.CrossCutting.Enums
{
    public enum DataBaseType
    {
        [Description(nameof(SqlServer))]
        SqlServer = 1,
    }
}
