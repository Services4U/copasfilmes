using CopaFilmes.Infrastructure.CrossCutting.Utilities.Extension;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.Domain.Entities.Domain
{
    public class Sample : Base
    {
        [Key]
        public int IdSample { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
