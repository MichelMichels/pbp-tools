using Microsoft.Win32;
using System.Windows;

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
        OpenFileDialog dialog = new()
        {
            DefaultExt = ".PBP",
            Filter = "PBP files (.PBP)|*.PBP"
        };

        bool? result = dialog.ShowDialog();
        if (result == true)
        {
            if(DataContext is MainViewModel viewModel)
            {
                viewModel.FilePath = dialog.FileName;
            }
        }
    }
}
