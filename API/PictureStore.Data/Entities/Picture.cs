using System.ComponentModel.DataAnnotations;

namespace PictureStore.Data.Entities;

public class Picture
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DateTime { get; set; }
    [Required]
    public byte[] Content { get; set; } = null!;
}
