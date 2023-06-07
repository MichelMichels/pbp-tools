using CommunityToolkit.Mvvm.ComponentModel;
using MichelMichels.PSP.PBP.Models;
using System;

namespace MichelMichels.PSP.PBP.Gui.ViewModels;

public partial class DefaultSubFileViewModel : ObservableObject
{
    protected readonly PbpSubFile model;
    public DefaultSubFileViewModel(PbpSubFile model)
    {
        this.model= model ?? throw new ArgumentNullException(nameof(model));
    }

    public string Name => model.FileName;
}
