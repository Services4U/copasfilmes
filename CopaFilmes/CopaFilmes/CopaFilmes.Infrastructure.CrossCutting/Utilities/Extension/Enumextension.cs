using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CopaFilmes.Infrastructure.CrossCutting.Utilities.Extension
{
    public static class Enumextension
    {
        public static string PesquisarDescricaoEnum(this Enum valorEnum)
        {
            try
            {
                return valorEnum.GetType()
                                   .GetMember(valorEnum.ToString())
                                   .First()
                                   .GetCustomAttribute<DescriptionAttribute>()
                                   .Description;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
