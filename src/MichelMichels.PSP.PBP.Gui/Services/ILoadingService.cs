using System;

namespace MichelMichels.PSP.PBP.Gui.Services;

public interface ILoadingService
{
    bool IsLoading { get; set; }

    event EventHandler? IsLoadingChanged;
}
