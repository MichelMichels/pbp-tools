using MichelMichels.PSP.PBP.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MichelMichels.PSP.PBP.Tests;

[TestClass()]
public class PbpFileUnpackerTests
{
    [TestMethod]
    public void ThrowsArgumentNullExceptionFileSystemService()
    {
        // Arrange
        Mock<IPbpUnpacker<Stream>> mockPbpStreamUnpacker = new();

        // Act
        Action action = new(() => _ = new PbpFileUnpacker(null!, mockPbpStreamUnpacker.Object));

        // Assert
        Assert.ThrowsException<ArgumentNullException>(action);
    }

    [TestMethod]
    public void ThrowsArgumentNullExceptionPbpStreamUnpacker()
    {
        // Arrange
        Mock<IFileSystemService> mockFileSystemService= new();

        // Act
        Action action = new(() => _ = new PbpFileUnpacker(mockFileSystemService.Object, null!));

        // Assert
        Assert.ThrowsException<ArgumentNullException>(action);
    }

    [TestMethod]
    public void ThrowsArgumentExceptionWhenFileDoesNotExist()
    {
        // Arrange
        Mock<IFileSystemService> mockFileSystemService = new();
        mockFileSystemService.Setup(x => x.IsExistingFile(It.IsAny<string>())).Returns(false);
        Mock<IPbpUnpacker<Stream>> mockPbpStreamUnpacker = new();

        PbpFileUnpacker unpacker = new PbpFileUnpacker(mockFileSystemService.Object, mockPbpStreamUnpacker.Object);

        // Act
        Action action = new(() => unpacker.Unpack("test", @"C:\test\"));

        // Assert
        Assert.ThrowsException<ArgumentException>(action);
    }

    [TestMethod]
    public void FileStreamPassedToPbpStreamUnpacker()
    {
        // Arrange
        Mock<IFileSystemService> mockFileSystemService = new();
        mockFileSystemService.Setup(x => x.IsExistingFile(It.IsAny<string>())).Returns(true);
        Mock<IPbpUnpacker<Stream>> mockPbpStreamUnpacker = new();

        PbpFileUnpacker unpacker = new(mockFileSystemService.Object, mockPbpStreamUnpacker.Object);

        // Act
        unpacker.Unpack("test", @"C:\test\");

        // Assert
        mockFileSystemService.Verify(x => x.OpenRead("test"), Times.Once());
        mockPbpStreamUnpacker.Verify(x => x.Unpack(It.IsAny<Stream>(), @"C:\test\"), Times.Once());
    }
}