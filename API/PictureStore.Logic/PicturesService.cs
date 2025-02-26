using PictureStore.Common.Entities;
using PictureStore.Data.Entities;
using PictureStore.Data.Interfaces;

namespace PictureStore.Service;

public class PicturesService : IPicturesService
{
    private readonly IPicturesRepository _picturesRepository;

    public PicturesService(IPicturesRepository picturesRepository)
    {
        ArgumentNullException.ThrowIfNull(picturesRepository);
        _picturesRepository = picturesRepository;
    }

    public async Task<Guid> AddPictureAsync(Picture pictureEntity)
    {
        if (await _picturesRepository.PictureExistsWithNameAsync(pictureEntity.Name))
        {
            throw new InvalidOperationException($"A picture with the name '{pictureEntity.Name}' already exists.");
        }

        _picturesRepository.AddPicture(pictureEntity);
        await _picturesRepository.SaveChangesAsync();

        return pictureEntity.Id;
    }

    public async Task<IEnumerable<PictureDataDto>> GetPicturesAsync()
    {
        return await _picturesRepository.GetPicturesAsync();
    }
}
