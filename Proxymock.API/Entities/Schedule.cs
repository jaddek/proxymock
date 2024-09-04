using System.ComponentModel.DataAnnotations.Schema;

namespace Proxymock.API.Entities
{
    [Table("schedule")]
    public class Schedule : BaseEntity
    {
        public Endpoint Url { get; set; } = null!;

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = null!;

        [ForeignKey("EndpointId")]
        public string Endpoint { get; set; } = null!;
    }
}