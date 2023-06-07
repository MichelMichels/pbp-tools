using CommunityToolkit.Mvvm.ComponentModel;
using MichelMichels.PSP.PBP.Gui.Services;
using MichelMichels.PSP.PBP.Gui.ViewModels;
using MichelMichels.PSP.PBP.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MichelMichels.PSP.PBP.Gui;

public partial class MainViewModel : ObservableObject
{
    private readonly IPbpLoader<string> pbpFileLoader;
    private readonly ILoadingService loadingService;

    [ObservableProperty]
    private PbpFile? currentPbpFile;

    [ObservableProperty]
    private string filePath = string.Empty;

    [ObservableProperty]
    private string filePathStatus = "No file loaded.";

    [ObservableProperty]
    private PbpSubFile? selectedSubFile;

    [ObservableProperty]
    private ObservableObject? detailViewModel;

    [ObservableProperty]
    private bool isLoading;

    public MainViewModel(IPbpLoader<string> pbpFileLoader, ILoadingService loadingService)
    {
        this.pbpFileLoader = pbpFileLoader ?? throw new ArgumentNullException(nameof(pbpFileLoader));
        this.loadingService = loadingService ?? throw new ArgumentNullException(nameof(loadingService));

        this.loadingService.IsLoadingChanged += LoadingService_IsLoadingChanged;
    }

    async partial void OnFilePathChanged(string? oldValue, string newValue)
    {
        if (string.IsNullOrEmpty(FilePath))
        {
            FilePathStatus = "No file loaded.";
            return;
        }

        loadingService.IsLoading = true;

        await Task.Run(() =>
        {
            CurrentPbpFile = pbpFileLoader.Load(FilePath);
            FilePathStatus = $"File: {FilePath}";
        });
        
        loadingService.IsLoading = false;
    }

    partial void OnSelectedSubFileChanged(PbpSubFile? oldValue, PbpSubFile? newValue)
    {
        if (newValue == null)
        {
            DetailViewModel = null;
            return;
        }

        DetailViewModel = newValue.FileName switch
        {
            "ICON0.PNG" => new IconZeroViewModel(newValue),
            "PIC1.PNG" => new PicOneViewModel(newValue),
            _ => new DefaultSubFileViewModel(newValue),
        };
    }

    private void LoadingService_IsLoadingChanged(object? sender, EventArgs e)
    {
        IsLoading = loadingService.IsLoading;
    }
}