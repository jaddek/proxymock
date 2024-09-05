using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proxymock.API.Entities
{
    [Table("endpoints")]
    public class Endpoint : BaseEntity
    {
        [StringLength(250)]
        public string Url { get; set; } = string.Empty;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = null!;
        [ForeignKey("SchemeId")]
        public Schema? Scheme { get; set; } = null;
    }
}