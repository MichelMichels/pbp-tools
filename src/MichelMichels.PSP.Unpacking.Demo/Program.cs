using MichelMichels.PSP.PBP;
using MichelMichels.PSP.PBP.Models;
using System.Diagnostics;
using MichelMichels.PSP.PBP.Services;

Console.WriteLine("PbpUnpacker v0.1");

PbpFileLoader pbpLoader = new PbpFileLoader(new WindowsFileSystemService(), new PbpStreamLoader());

PbpFile file = pbpLoader.Load("EBOOT.PBP");

Console.WriteLine("Following files found:");
foreach(PbpSubFile subFile in file.SubFiles)
{
    Console.WriteLine($"{subFile.FileName} | {subFile.Data.Length} bytes");
}
