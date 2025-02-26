using Moq;
using PictureStore.Common.Entities;
using PictureStore.Data.Entities;
using PictureStore.Data.Interfaces;
using PictureStore.Service;

namespace PicturesStore.Tests;

[TestFixture]
public class ServiceTests
{
    private Mock<IPicturesRepository> _mockRepository;
    private PicturesService _picturesService;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IPicturesRepository>();
        _picturesService = new PicturesService(_mockRepository.Object);
    }

    [Test]
    public async Task AddPictureAsync_ShouldCallRepositoryAndReturnId()
    {
        // Arrange
        var picture = new Picture { Id = Guid.NewGuid(), Name = "Test Picture" };

        // Act
        var result = await _picturesService.AddPictureAsync(picture);

        // Assert
        _mockRepository.Verify(repo => repo.AddPicture(It.Is<Picture>(p => p == picture)), Times.Once);
        _mockRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        Assert.That(picture.Id, Is.EqualTo(result));
    }

    [Test]
    public async Task GetPicturesAsync_ShouldReturnListOfPictures()
    {
        // Arrange
        var expectedPictures = new List<PictureDataDto>
            {
                new PictureDataDto { Id = Guid.NewGuid(), Name = "Picture 1" },
                new PictureDataDto { Id = Guid.NewGuid(), Name = "Picture 2" }
            };

        _mockRepository
            .Setup(repo => repo.GetPicturesAsync())
            .ReturnsAsync(expectedPictures);

        // Act
        var result = await _picturesService.GetPicturesAsync();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(expectedPictures, Has.Count.EqualTo(result.Count()));
        });
        CollectionAssert.AreEqual(expectedPictures, result);
    }

    [Test]
    public void Constructor_ShouldThrowArgumentNullException_WhenRepositoryIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new PicturesService(null));
    }
}