using System.ComponentModel.DataAnnotations;

namespace ConfigServer.Application.DTOs;

public class CreateApplicationDTO
{
    [Required(ErrorMessage = "application name can't be null!"),
        MaxLength(150, ErrorMessage = "application name can't be more than 150 characther."),
        MinLength(2, ErrorMessage = "application name can't be less than 2 characther")]
    public string ApplicationName { get; set; } = string.Empty;

    [Required(ErrorMessage = "application configuration can't be null!")]
    public string Configuration { get; set; } = string.Empty;
}
