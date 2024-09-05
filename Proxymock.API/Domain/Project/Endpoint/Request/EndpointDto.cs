using System.ComponentModel.DataAnnotations;

namespace Proxymock.API.Domain.Project.Endpoint.Request;

public class EndpointDto(string url)
{
    [Required(AllowEmptyStrings = false), StringLength(200)]
    public string Url { get; set; } = url;
}