using PictureStore.Common.Entities;
using PictureStore.Data.Entities;

namespace PictureStore.Data.Interfaces;

/// <summary>
/// Defines the contract for interacting with the picture data store.
/// </summary>
public interface IPicturesRepository
{
    /// <summary>
    /// Retrieves all pictures stored in the repository.
    /// </summary>
    /// <returns>A collection of <see cref="PictureDataDto"/> representing the stored pictures.</returns>
    Task<IEnumerable<PictureDataDto>> GetPicturesAsync();

    /// <summary>
    /// Adds a new picture to the repository.
    /// </summary>
    /// <param name="pictureToAdd">The <see cref="Picture"/> entity to add.</param>
    void AddPicture(Picture pictureToAdd);

    /// <summary>
    /// Persists all changes made to the repository.
    /// </summary>
    /// <returns>A boolean indicating whether any changes were successfully saved.</returns>
    Task<bool> SaveChangesAsync();

    /// <summary>
    /// Checks if picture witha specific name already exists.
    /// </summary>
    /// <param name="name"></param>
    /// <returns>A boolean indicating whether picture with the given name exists.</returns>
    Task<bool> PictureExistsWithNameAsync(string name);
}