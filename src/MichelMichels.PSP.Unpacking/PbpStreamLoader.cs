using MichelMichels.PSP.PBP.Exceptions;
using MichelMichels.PSP.PBP.Models;
using System.Text;

namespace MichelMichels.PSP.PBP;

public class PbpStreamLoader : IPbpLoader<Stream>
{
    private const int PbpSignatureByteCount = 4;

    public PbpFile Load(Stream stream)
    {
        if (stream.Length < Constants.PbpHeaderSize)
        {
            throw new ArgumentException($"File size ({stream.Length}) is smaller than the PBP header size ({Constants.PbpHeaderSize})", nameof(stream));
        }

        string filePath = string.Empty;
        if (stream is FileStream fs)
        {
            filePath = fs.Name;
        }

        PbpFile file = new()
        {
            TotalSize = Convert.ToInt32(stream.Length),
            Header = ReadPbpHeader(stream)
        };

        int unpackedFileSize;
        for (int i = 0; i < Constants.PbpSubFiles.Length; i++)
        {
            if (i == 7)
            {
                unpackedFileSize = file.TotalSize - file.Header.Offsets[i];
            }
            else
            {
                unpackedFileSize = file.Header.Offsets[i + 1] - file.Header.Offsets[i];
            }

            if (unpackedFileSize == 0)
            {
                continue;
            }

            _ = stream.Seek(file.Header.Offsets[i], SeekOrigin.Begin);

            PbpSubFile subFile = new(Constants.PbpSubFiles[i], new byte[unpackedFileSize]);
            stream.ReadExactly(subFile.Data, 0, unpackedFileSize);
            file.SubFiles.Add(subFile);
        }

        return file;
    }

    private PbpHeader ReadPbpHeader(Stream stream)
    {
        using BinaryReader reader = new(stream, Encoding.UTF8, true);

        byte[] signature = reader.ReadBytes(PbpSignatureByteCount);
        if (!signature.SequenceEqual(Constants.ValidPbpSignature))
        {
            throw new InvalidPbpHeaderException("Signature should be 0x00, 0x50, 0x42, 0x50.");
        }

        PbpHeader header = new()
        {
            Signature = signature,
            Version = reader.ReadInt32(),
        };

        for (int i = 0; i < 8; i++)
        {
            header.Offsets[i] = reader.ReadInt32();
        }

        return header;
    }
}
