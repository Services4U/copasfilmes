using CopaFilmes.Infrastructure.CrossCutting.Utilities.Extension;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.Domain.Entities.Domain
{
    public class SampleDetail : Base
    {
        [Key]
        public int IdSampleDetail { get; set; }
        public int IdSampleComposite { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
