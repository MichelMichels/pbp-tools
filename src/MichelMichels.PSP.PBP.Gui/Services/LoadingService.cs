using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MichelMichels.PSP.PBP.Gui.Services;

public partial class LoadingService : ObservableObject, ILoadingService
{
    [ObservableProperty]
    private bool isLoading;

    public event EventHandler? IsLoadingChanged;

    partial void OnIsLoadingChanged(bool value) => IsLoadingChanged?.Invoke(this, EventArgs.Empty);    
}
