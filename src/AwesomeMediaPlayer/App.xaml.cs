using AwesomeMediaPlayer.Configuration;
using AwesomeMediaPlayer.UI.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace AwesomeMediaPlayer;

/// <summary>
/// Interaction logic for App.xaml.
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _rootServiceProvider = CreateContainer();

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        InitializeComponent();
    }

    private static ServiceProvider CreateContainer()
    {
        ServiceCollection services = [];

        ServiceConfiguration.Configure(services);

        ServiceProvider rootServiceProvider = services.BuildServiceProvider();

        Ioc.Default.ConfigureServices(rootServiceProvider);

        return rootServiceProvider;
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        _rootServiceProvider.GetRequiredService<MainWindow>().Activate();
    }
}