using MichelMichels.PSP.PBP.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MichelMichels.PSP.PBP.Tests;

[TestClass()]
public class PbpStreamLoaderTests
{
    [TestMethod]
    public void InvalidPbpHeaderTest()
    {
        // Arrange
        byte[] invalidSignature = new byte[40];
        Stream mockPbpStream = new MemoryStream(invalidSignature);

        IPbpLoader<Stream> pbpLoader = new PbpStreamLoader();

        // Act
        Assert.ThrowsException<InvalidPbpHeaderException>(() => pbpLoader.Load(mockPbpStream));
    }

    [TestMethod]
    public void ZeroLengthStreamTest()
    {
        // Arrange

        // Act
        IPbpLoader<Stream> pbpLoader = new PbpStreamLoader();

        // Assert
        Assert.ThrowsException<ArgumentException>(() => pbpLoader.Load(Stream.Null));
    }

    [TestMethod]
    public void ValidPbpHeaderTest()
    {
        // Arrange
        byte[] signature = new byte[40];
        signature[1] = 0x50; // P
        signature[2] = 0x42; // B
        signature[3] = 0x50; // P
        Stream stream = new MemoryStream(signature);
        IPbpLoader<Stream> loader = new PbpStreamLoader();  

        // Act
        loader.Load(stream);
    }
}