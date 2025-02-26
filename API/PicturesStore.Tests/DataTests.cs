using Microsoft.EntityFrameworkCore;
using PictureStore.Data;
using PictureStore.Data.DbContexts;
using PictureStore.Data.Entities;

namespace PicturesStore.Tests;

[TestFixture]
public class DataTests
{
    private PicturesContext _dbContext;
    private PicturesRepository _repository;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<PicturesContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _dbContext = new PicturesContext(options);
        _repository = new PicturesRepository(_dbContext);
    }

    [TearDown]
    public void Cleanup()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }

    [Test]
    public async Task AddPicture_ShouldAddPictureToDatabase()
    {
        // Arrange
        var picture = new Picture
        {
            Name = "Test Picture",
            Description = "Sample description",
            DateTime = DateTime.UtcNow,
            Content = new byte[] { 1, 2, 3 }
        };
        // Act
        _repository.AddPicture(picture);
        await _repository.SaveChangesAsync();

        // Assert
        var savedPicture = await _dbContext.Pictures.FindAsync(picture.Id);
        Assert.That(savedPicture, Is.Not.Null);
        Assert.That(picture.Id, Is.Not.EqualTo(Guid.Empty));
        Assert.That(savedPicture?.Name, Is.EqualTo(picture.Name));
        Assert.That(savedPicture?.Description, Is.EqualTo(picture.Description));
        Assert.That(savedPicture?.DateTime, Is.EqualTo(picture.DateTime));
    }

    [Test]
    public async Task GetPicturesAsync_ShouldReturnAllPictures()
    {
        // Arrange
        var picture1 = new Picture
        {
            Name = "Picture 1",
            Description = "Desc 1",
            DateTime = DateTime.UtcNow,
            Content = new byte[] { 1, 2, 3 } 
        };

        var picture2 = new Picture
        {
            Name = "Picture 2",
            Description = "Desc 2",
            DateTime = DateTime.UtcNow,
            Content = new byte[] { 4, 5, 6 }
        };

        _dbContext.Pictures.AddRange(picture1, picture2);
        await _dbContext.SaveChangesAsync();

        // Act
        var pictures = await _repository.GetPicturesAsync();

        // Assert
        Assert.That(pictures, Is.Not.Null);
        Assert.That(pictures.Count(), Is.EqualTo(2));
    }

    [Test]
    public async Task SaveChangesAsync_ShouldReturnFalse_WhenNoChanges()
    {
        // Act
        var result = await _repository.SaveChangesAsync();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenContextIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new PicturesRepository(null));
    }
}
