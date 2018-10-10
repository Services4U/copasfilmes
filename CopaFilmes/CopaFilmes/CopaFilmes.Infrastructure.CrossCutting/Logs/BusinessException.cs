using System;

namespace CopaFilmes.Infrastructure.CrossCutting.Logs
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
            Log.Error(this, message);
        }
    }
}
