using MichelMichels.PSP.PBP.Gui.Services;
using MichelMichels.PSP.PBP.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MichelMichels.PSP.PBP.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider? ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            ServiceCollection serviceCollection = new();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            MainView view = ServiceProvider.GetRequiredService<MainView>();
            view.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(MainView));
            services.AddTransient<IPbpLoader<Stream>, PbpStreamLoader>();
            services.AddTransient<IPbpLoader<string>, PbpFileLoader>();
            services.AddTransient<IPbpUnpacker<Stream>, PbpStreamUnpacker>();
            services.AddTransient<IPbpUnpacker<string>, PbpFileUnpacker>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<IFileSystemService, WindowsFileSystemService>();
            services.AddSingleton<ILoadingService, LoadingService>();
        }

    }
}
