using Ookii.Dialogs.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace MichelMichels.PSP.PBP.Gui;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public partial class MainView : Window
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void OpenFileDialog_Click(object sender, RoutedEventArgs e)
    {
        Ookii.Dialogs.Wpf.VistaOpenFileDialog dialog = new()
        {
            DefaultExt = ".PBP",
            Filter = "PBP files (.PBP)|*.PBP"
        };

        bool isNotCancelled = dialog.ShowDialog() ?? false;
        if (isNotCancelled)
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.LoadPbpFileCommand.Execute(dialog.FileName);
            }
        }
    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri)
        {
            UseShellExecute = true,
        });
        e.Handled = true;
    }

    private void ExtractAll_Click(object sender, RoutedEventArgs e)
    {
        VistaFolderBrowserDialog dialog = new()
        {
            Multiselect = false,
            RootFolder = Environment.SpecialFolder.MyDocuments,
            ShowNewFolderButton = true,
            Description = "Choose a folder for the extracted files",
        };

        bool isNotCancelled = dialog.ShowDialog() ?? false;
        if (isNotCancelled)
        {
            if (DataContext is MainViewModel viewModel)
            {
                viewModel.ExtractAllFilesCommand.Execute(dialog.SelectedPath);
            }
        }
    }
}
