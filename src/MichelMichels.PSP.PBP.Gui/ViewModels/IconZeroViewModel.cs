using CommunityToolkit.Mvvm.ComponentModel;
using MichelMichels.PSP.PBP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing.IndexedProperties;
using System.Text;
using System.Threading.Tasks;

namespace MichelMichels.PSP.PBP.Gui.ViewModels;

public partial class IconZeroViewModel : ImageViewModel
{
    public IconZeroViewModel(PbpSubFile iconZeroModel) : base(iconZeroModel)
    {
        this.Height = 100;
    }
}
