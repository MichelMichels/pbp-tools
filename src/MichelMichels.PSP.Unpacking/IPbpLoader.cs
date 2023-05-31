using MichelMichels.PSP.PBP.Models;

namespace MichelMichels.PSP.PBP;

public interface IPbpLoader<T>
{
    PbpFile Load(T source);
}
