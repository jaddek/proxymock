using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proxymock.API.Entities
{
    public class Schema : BaseEntity
    {
        [StringLength(250)]
        public string? Title { get; set; }

        [ForeignKey("EndpointId")] public Endpoint Endpoint { get; set; } = null!;
        [Column(TypeName = "jsonb")]
        [StringLength(5000)]
        public string? Body { get; set; } 
    }
}