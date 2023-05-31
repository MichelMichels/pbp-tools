using CommunityToolkit.Mvvm.ComponentModel;
using MichelMichels.PSP.PBP.Models;
using System;

namespace MichelMichels.PSP.PBP.Gui;

public partial class MainViewModel : ObservableObject
{
    private readonly IPbpLoader<string> pbpFileLoader;

    [ObservableProperty]
    private PbpFile? currentPbpFile;

    [ObservableProperty]
    private string filePath = string.Empty;

    public MainViewModel(IPbpLoader<string> pbpFileLoader)
    {
        this.pbpFileLoader = pbpFileLoader ?? throw new ArgumentNullException(nameof(pbpFileLoader));
    }

    partial void OnFilePathChanged(string? oldValue, string newValue)
    {
        if(string.IsNullOrEmpty(FilePath))
        {
            return;
        }

        CurrentPbpFile = pbpFileLoader.Load(FilePath);
    }
}
