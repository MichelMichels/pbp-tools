namespace MichelMichels.PSP.PBP;

internal class Constants
{
    internal const int PbpSignatureSize = 4;
    internal const int PbpVersionSize = 4;
    internal const int PbpOffsetsSize = 8 * 4;
    internal const int PbpHeaderSize = PbpSignatureSize + PbpVersionSize + PbpOffsetsSize;

    internal static byte[] ValidPbpSignature = new byte[4]
    {
        0x00,
        0x50, // P
        0x42, // B
        0x50  // P
    };

    internal static string[] PbpSubFiles = new string[]
    {
       "PARAM.SFO",
       "ICON0.PNG",
       "ICON1.PMF",
       "PIC0.PNG",
       "PIC1.PNG",
       "SND0.AT3",
       "DATA.PSP",
       "DATA.PSAR"
    };
}
