using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proxymock.API.Entities
{
    [Table("projects")]
    public class Project : BaseEntity
    {
        [StringLength(250)]
        public string Title { get; set; } = string.Empty;
        public ICollection<Endpoint>? Urls { get; }
    }
}