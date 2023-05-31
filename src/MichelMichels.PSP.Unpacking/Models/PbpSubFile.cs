namespace MichelMichels.PSP.PBP.Models;

public class PbpSubFile
{
    public PbpSubFile(string fileName, byte[] data)
    {
        FileName = fileName;
        Data = data;
    }
    public string FileName { get; set; }
    public byte[] Data { get; set; }
}
