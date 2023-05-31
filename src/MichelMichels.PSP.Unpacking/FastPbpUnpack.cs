using MichelMichels.PSP.PBP.Services;

namespace MichelMichels.PSP.PBP;

public static class FastPbpUnpack
{
    private static IPbpUnpacker<string>? pbpUnpacker;

    public static void Unpack(string filePath)
    {            
        Unpack(filePath, Directory.GetParent(filePath)!.FullName);
    }

    public static void Unpack(string filePath, string outputDirectory)
    {
        pbpUnpacker ??= InitializePbpUnpacker();

        pbpUnpacker.Unpack(filePath, outputDirectory);
    }

    private static IPbpUnpacker<string> InitializePbpUnpacker()
    {
        IFileSystemService fileSystemService = new WindowsFileSystemService();

        return new PbpFileUnpacker(
            fileSystemService,
            new PbpStreamUnpacker(
                fileSystemService,
                new PbpStreamLoader()));
    }
}
