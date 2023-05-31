using MichelMichels.PSP.PBP.Models;
using MichelMichels.PSP.PBP.Services;

namespace MichelMichels.PSP.PBP;

public class PbpFileLoader : IPbpLoader<string>
{
    private readonly IFileSystemService fileSystemService;
    private readonly IPbpLoader<Stream> pbpStreamLoader;

    public PbpFileLoader(IFileSystemService fileSystemService, IPbpLoader<Stream> pbpStreamLoader)
    {
        this.fileSystemService = fileSystemService ?? throw new ArgumentNullException(nameof(fileSystemService));
        this.pbpStreamLoader = pbpStreamLoader ?? throw new ArgumentNullException(nameof(pbpStreamLoader));
    }

    public PbpFile Load(string source)
    {
        using FileStream stream = fileSystemService.OpenRead(source);
        return pbpStreamLoader.Load(stream);
    }  
}
