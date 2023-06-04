using CommunityToolkit.Mvvm.ComponentModel;
using MichelMichels.PSP.PBP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MichelMichels.PSP.PBP.Gui.ViewModels
{
    public abstract partial class ImageViewModel : ObservableObject
    {
        protected readonly PbpSubFile model;

        [ObservableProperty]
        private BitmapMetadata metadata;

        public ImageViewModel(PbpSubFile model)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));

            using MemoryStream ms = new(model.Data);
            BitmapSource bitmap = BitmapFrame.Create(ms);
            metadata = (BitmapMetadata)bitmap.Metadata;
        }

        public string Name => model.FileName;
        public byte[] ImageData => model.Data;
        public double Height { get; set; }

        public bool WriteImageToDisk(string filePath)
        {
            try
            {
                File.WriteAllBytes(filePath, ImageData);
            } catch
            {
                return false;
            }

            return true;
        }
    }
}
