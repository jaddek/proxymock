using System.ComponentModel.DataAnnotations;

namespace Proxymock.API.Domain.Project.Schema.Request;

public class SchemaDto
{
    [Required(AllowEmptyStrings = false)]
    public string Title { get; set; } = string.Empty;
    [Required(AllowEmptyStrings = false)]
    public string Body { get; set; } = string.Empty;
}