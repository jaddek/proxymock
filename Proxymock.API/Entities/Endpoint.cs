using System.ComponentModel.DataAnnotations.Schema;

namespace Proxymock.API.Entities
{
    [Table("endpoints")]
    public class Endpoint : BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = null!;
        [ForeignKey("SchemeId")]
        public Scheme? Scheme { get; set; } = null;
    }
}