using Microsoft.AspNetCore.Mvc;
using PictureStore.API.Entities;
using PictureStore.Data.Entities;
using PictureStore.Service;

namespace PictureStore.API.Controllers;

[ApiController]
[Route("api/pictures/")]
public class PicturesController : ControllerBase
{
    private readonly IPicturesService _picturesService;
    private readonly ILogger<PicturesController> _logger;
    public PicturesController(IPicturesService picturesService, ILogger<PicturesController> logger)
    {
        _picturesService = picturesService;
        _logger = logger;
    }

    /// <summary>
    /// Uploads a new picture.
    /// </summary>
    /// <param name="request">The picture creation data including name, description, and file content</param>
    /// <returns>The Id of the created picture in the Db.</returns>
    [HttpPost]
    public async Task<IActionResult> CreatePicture([FromForm] PictureForCreationDto request)
    {
        _logger.LogInformation("Received a request to add a picture: {PictureName}", request.Name);
        using var memoryStream = new MemoryStream();
        await request.Content.CopyToAsync(memoryStream);

        var pictureToAdd = new Picture
        {
            Name = request.Name,
            Description = request.Description,
            Content = memoryStream.ToArray(),
            DateTime = request.DateTime,
        };

        try
        {
            var id = await _picturesService.AddPictureAsync(pictureToAdd);
            return Created("", new { id });
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogWarning("Duplicate picture name: {PictureName}", request?.Name);
            return Conflict(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Retrieves all stored pictures.
    /// </summary>
    /// <returns>A collection of pictures with metadata</returns>
    [HttpGet]
    public async Task<IActionResult> GetPictures()
    {
        _logger.LogInformation("Fetching all pictures from the database.");
        var bookEntities = await _picturesService.GetPicturesAsync();
        return Ok(bookEntities);
    }
}
