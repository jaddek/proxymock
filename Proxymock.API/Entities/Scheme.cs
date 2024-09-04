using System.ComponentModel.DataAnnotations.Schema;

namespace Proxymock.API.Entities
{
    public class Scheme : BaseEntity
    {
        public string Url { get; set; } = String.Empty;
        [ForeignKey("EndpointId")]
        public Endpoint Endpoint { get; set; } = null!;
        [Column(TypeName = "jsonb")]
        public string? JsonData { get; set; } = null;
    }
}