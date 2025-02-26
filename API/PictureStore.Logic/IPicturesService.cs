using PictureStore.Common.Entities;
using PictureStore.Data.Entities;

namespace PictureStore.Service;

/// <summary>
/// Defines operations for managing pictures in the database.
/// </summary>
public interface IPicturesService
{
    /// <summary>
    /// Retrieves all pictures stored in the database.
    /// </summary>
    /// <returns>A collection of <see cref="PictureDataDto"/> representing the stored pictures.</returns>
    Task<IEnumerable<PictureDataDto>> GetPicturesAsync();

    /// <summary>
    /// Adds a new picture to the database.
    /// </summary>
    /// <param name="request">The <see cref="Picture"/> entity containing picture data to be stored.</param>
    /// <returns>The unique identifier (<see cref="Guid"/>) of the newly added picture.</returns>
    Task<Guid> AddPictureAsync(Picture request);
}
