using System;

namespace CopaFilmes.Domain.Entities
{
    public class Base
    {
        public int? UsuarioCadastro { get; set; }
        public int? UsuarioAtualizacao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int? Ativo { get; set; }
    }
}
