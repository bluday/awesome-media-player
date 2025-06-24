using BluDay.Net.DependencyInjection;
using BluDay.Net.Extensions;
using BluDay.Net.WinUI3.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.Windows.ApplicationModel.Resources;

namespace Amp;

public sealed partial class App
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(ConfigureLogging);

        services.AddMemoryCache();

        services.AddSingleton<WeakReferenceMessenger>();

        services
            .AddSingleton<App>()
            .AddSingleton<ResourceLoader>();

        services
            .AddSingleton<ImplementationProvider<ObservableObject>>()
            .AddSingleton<ImplementationProvider<Window>>();

        services
            .AddPages()
            .AddViewModels()
            .AddWindows();
    }
}