using MichelMichels.PSP.PBP.Models;
using MichelMichels.PSP.PBP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichelMichels.PSP.PBP;

public class PbpStreamUnpacker : IPbpUnpacker<Stream>
{
    private readonly IFileSystemService fileSystemService;
    private readonly IPbpLoader<Stream> pbpStreamLoader;

    public PbpStreamUnpacker(IFileSystemService fileSystemService, IPbpLoader<Stream> pbpStreamLoader)
    {
        this.fileSystemService = fileSystemService ?? throw new ArgumentNullException(nameof(fileSystemService));   
        this.pbpStreamLoader = pbpStreamLoader ?? throw new ArgumentNullException(nameof(pbpStreamLoader));
    }

    public void Unpack(Stream stream, string outputDirectory)
    {
        PbpFile pbpFile = pbpStreamLoader.Load(stream);

        if (!fileSystemService.IsExistingDirectory(outputDirectory))
        {
            fileSystemService.CreateDirectory(outputDirectory);
        }

        foreach (PbpSubFile file in pbpFile.SubFiles)
        {
            string filePath = Path.Combine(outputDirectory, file.FileName);
            fileSystemService.WriteAllBytes(filePath, file.Data);
        }
    }
}
