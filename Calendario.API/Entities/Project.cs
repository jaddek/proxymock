using System.ComponentModel.DataAnnotations.Schema;

namespace Calendario.API.Entities
{
    [Table("projects")]
    public class Project : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public ICollection<Endpoint>? Urls { get; }
    }
}