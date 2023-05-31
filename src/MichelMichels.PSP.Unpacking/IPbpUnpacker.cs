namespace MichelMichels.PSP.PBP;

public interface IPbpUnpacker<T>
{
    void Unpack(T value, string outputDirectory);
}
