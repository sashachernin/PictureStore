using System.ComponentModel.DataAnnotations;

namespace PictureStore.API.Entities;

public class PictureForCreationDto
{
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DateTime { get; set; }
    [Required]
    public IFormFile Content { get; set; } = null!;
}
