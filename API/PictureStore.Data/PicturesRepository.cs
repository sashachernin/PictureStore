using Microsoft.EntityFrameworkCore;
using PictureStore.Common.Entities;
using PictureStore.Data.DbContexts;
using PictureStore.Data.Entities;
using PictureStore.Data.Interfaces;

namespace PictureStore.Data;

public class PicturesRepository : IPicturesRepository
{
    private readonly PicturesContext _context;

    public PicturesRepository(PicturesContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        _context = context;
    }
    public void AddPicture(Picture pictureToAdd)
    {
        ArgumentNullException.ThrowIfNull(pictureToAdd);
        _context.Add(pictureToAdd);
    }

    public async Task<IEnumerable<PictureDataDto>> GetPicturesAsync()
    {
        return await _context.Pictures
            .Select(p => new PictureDataDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                DateTime = p.DateTime
            })
            .ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> PictureExistsWithNameAsync(string name)
    {
        return await _context.Pictures.AnyAsync(p => p.Name == name);
    }
}
