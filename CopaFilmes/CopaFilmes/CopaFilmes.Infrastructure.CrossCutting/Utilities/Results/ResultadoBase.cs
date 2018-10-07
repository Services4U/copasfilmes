using System.Collections.Generic;

namespace CopaFilmes.Infrastructure.CrossCutting.Utilities.Results
{
    public class ResultadoBase
    {
        public ResultadoBase()
        {
            Excecao = new List<Excecao>();
        }

        public ResultadoBase(string codigo, string mensagem, string rastreamento)
        {
            if (Excecao == null)
                Excecao = new List<Excecao>();

            var excecao = new Excecao
            {
                Codigo = codigo,
                Mensagem = mensagem,
                Rastreamento = rastreamento
            };
            Excecao.Add(excecao);
        }

        public List<Excecao> Excecao { get; set; }
    }
}
