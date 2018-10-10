using CopaFilmes.Infrastructure.CrossCutting.Utilities.Extension;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CopaFilmes.Domain.Entities.Domain
{
    public class SampleComposite : Base
    {
        [Key]
        public int IdSampleComposite { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<SampleDetail> SampleDetails { get; set; }
    }
}
