namespace MichelMichels.PSP.PBP.Models;

public class PbpHeader
{
    public byte[] Signature { get; set; } = new byte[4];
    public int Version { get; set; }
    public int[] Offsets { get; set; } = new int[8];
}
