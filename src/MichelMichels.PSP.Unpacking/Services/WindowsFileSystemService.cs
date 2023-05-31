using System.ComponentModel;

namespace MichelMichels.PSP.PBP.Services;

public class WindowsFileSystemService : IFileSystemService
{
    public void CreateDirectory(string path)
    {
        Directory.CreateDirectory(path);
    }

    public bool IsExistingDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public bool IsExistingFile(string path)
    {
        return File.Exists(path);
    }

    public FileStream OpenRead(string path)
    {
        return File.OpenRead(path);
    }

    public void WriteAllBytes(string path, byte[] bytes)
    {
        File.WriteAllBytes(path, bytes);
    }
}
