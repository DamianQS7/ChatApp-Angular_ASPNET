using System;
using System.ComponentModel.DataAnnotations;

namespace API.Shared.Configuration;

public class JwtSettings
{
    [Required]
    public required string SecurityKey { get; set; }
}
