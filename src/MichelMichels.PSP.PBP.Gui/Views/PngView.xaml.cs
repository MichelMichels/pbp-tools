using MichelMichels.PSP.PBP.Gui.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace MichelMichels.PSP.PBP.Gui.Views;

/// <summary>
/// Interaction logic for PngView.xaml
/// </summary>
public partial class PngView : UserControl
{
    public PngView()
    {
        InitializeComponent();
    }

    private void ExtractImage_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog dialog = new()
        {
            DefaultExt = ".png",
            Filter = "PNG files (.png)|*.png"
        };

        bool? result = dialog.ShowDialog();
        if (result == true)
        {
            if (DataContext is ImageViewModel viewModel)
            {
                viewModel.WriteImageToDisk(dialog.FileName);
            }
        }
    }
}
