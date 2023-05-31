namespace MichelMichels.PSP.PBP.Models;

public class PbpFile
{
    public int TotalSize { get; set; }
    public PbpHeader Header { get; set; } = new();
    public List<PbpSubFile> SubFiles { get; set; } = new();
}
