using System.ComponentModel.DataAnnotations;

namespace Proxymock.API.Domain.Project.Project.Request;

public class ProjectDto(string title)
{
    [Required(AllowEmptyStrings = false), StringLength(200)]
    public string Title { get; set; } = title;
}