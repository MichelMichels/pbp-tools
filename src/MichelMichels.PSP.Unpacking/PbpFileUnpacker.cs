using MichelMichels.PSP.PBP.Services;

namespace MichelMichels.PSP.PBP;

public class PbpFileUnpacker : IPbpUnpacker<string>
{
    private readonly IFileSystemService fileSystemService;
    private readonly IPbpUnpacker<Stream> pbpStreamUnpacker;

    public PbpFileUnpacker(IFileSystemService fileSystemService, IPbpUnpacker<Stream> pbpStreamUnpacker)
    {
        this.fileSystemService = fileSystemService ?? throw new ArgumentNullException(nameof(fileSystemService));
        this.pbpStreamUnpacker = pbpStreamUnpacker ?? throw new ArgumentNullException(nameof(pbpStreamUnpacker));
    }

    public void Unpack(string filePath, string outputDirectory)
    {
        if (!fileSystemService.IsExistingFile(filePath))
        {
            throw new ArgumentException("Provided file does not exist.", nameof(filePath));
        }

        using FileStream stream = fileSystemService.OpenRead(filePath);

        pbpStreamUnpacker.Unpack(stream, outputDirectory);
    }
}
