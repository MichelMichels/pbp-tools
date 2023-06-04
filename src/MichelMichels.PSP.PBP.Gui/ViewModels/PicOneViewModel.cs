using CommunityToolkit.Mvvm.ComponentModel;
using MichelMichels.PSP.PBP.Models;
using System.IO;
using System.Windows.Media.Imaging;

namespace MichelMichels.PSP.PBP.Gui.ViewModels;

public partial class PicOneViewModel : ImageViewModel
{
    public PicOneViewModel(PbpSubFile model) : base(model)
    {
        this.Height = 272;
    }   
}
