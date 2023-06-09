using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichelMichels.PSP.PBP.Gui.Services;
using MichelMichels.PSP.PBP.Gui.ViewModels;
using MichelMichels.PSP.PBP.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MichelMichels.PSP.PBP.Gui;

public partial class MainViewModel : ObservableObject
{
    private readonly IPbpLoader<string> pbpFileLoader;
    private readonly IPbpUnpacker<string> pbpFileUnpacker;
    private readonly ILoadingService loadingService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanExtractAll))]
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

    public MainViewModel(IPbpLoader<string> pbpFileLoader, IPbpUnpacker<string> pbpFileUnpacker, ILoadingService loadingService)
    {
        this.pbpFileLoader = pbpFileLoader ?? throw new ArgumentNullException(nameof(pbpFileLoader));
        this.pbpFileUnpacker = pbpFileUnpacker ?? throw new ArgumentNullException(nameof(pbpFileUnpacker));
        this.loadingService = loadingService ?? throw new ArgumentNullException(nameof(loadingService));

        this.loadingService.IsLoadingChanged += LoadingService_IsLoadingChanged;
    }

    public bool CanExtractAll => CurrentPbpFile != null;

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

    [RelayCommand]
    private async Task LoadPbpFile(string filePath)
    {
        FilePath = filePath;

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

    [RelayCommand(CanExecute = nameof(CanExtractAll))]
    private async Task ExtractAllFiles(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        loadingService.IsLoading = true;
        await Task.Run(() => pbpFileUnpacker.Unpack(FilePath, folderPath));
        loadingService.IsLoading = false;
    }
}