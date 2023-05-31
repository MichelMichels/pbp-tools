namespace MichelMichels.PSP.PBP.Services;

public interface IFileSystemService
{
    bool IsExistingFile(string path);
    bool IsExistingDirectory(string path);

    void CreateDirectory(string path);

    FileStream OpenRead(string path);

    void WriteAllBytes(string path, byte[] bytes);
}
