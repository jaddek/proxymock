using System.ComponentModel.DataAnnotations;

namespace Proxymock.API.Domain.Project.Request
{
    public class ProjectDTO(string title)
    {
        [Required(AllowEmptyStrings = false), StringLength(200)]
        public string Title { get; set; } = title;
    }
}