using MichelMichels.PSP.PBP.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MichelMichels.PSP.PBP.Tests;

[TestClass()]
public class PbpStreamUnpackerTests
{
    private readonly Mock<IFileSystemService> mockFileSystemService = new();
    private readonly Mock<IPbpLoader<Stream>> mockPbpStreamLoader = new();

    [TestMethod]
    public void ThrowsArgumentNullExceptionFileSystemService()
    {
        // Arrange

        // Act
        Action action = () => _ = new PbpStreamUnpacker(null!, mockPbpStreamLoader.Object);

        // Assert
        Assert.ThrowsException<ArgumentNullException>(action);
    }

    [TestMethod]
    public void ThrowsArgumentNullExceptionPbpStreamLoader()
    {
        // Arrange

        // Act
        Action action = () => _ = new PbpStreamUnpacker(mockFileSystemService.Object, null!);

        // Assert
        Assert.ThrowsException<ArgumentNullException>(action);
    }

    [TestMethod]
    public void CreateDirectoryTest()
    {
        // Arrange
        mockFileSystemService.Reset();
        mockFileSystemService.Setup(x => x.IsExistingDirectory(It.IsAny<string>())).Returns(false);
        mockPbpStreamLoader.Reset();
        mockPbpStreamLoader.Setup(x => x.Load(It.IsAny<Stream>())).Returns(new Models.PbpFile());

        // Act
        PbpStreamUnpacker unpacker = new PbpStreamUnpacker(mockFileSystemService.Object, mockPbpStreamLoader.Object);
        unpacker.Unpack(Stream.Null, "test directory");

        // Assert
        mockFileSystemService.Verify(x => x.IsExistingDirectory("test directory"), Times.Once());
        mockFileSystemService.Verify(x => x.CreateDirectory("test directory"), Times.Once());
        mockFileSystemService.VerifyNoOtherCalls();
    }
}