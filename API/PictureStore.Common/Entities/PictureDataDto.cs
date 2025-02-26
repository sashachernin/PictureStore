namespace PictureStore.Common.Entities;

public class PictureDataDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DateTime { get; set; }
}
