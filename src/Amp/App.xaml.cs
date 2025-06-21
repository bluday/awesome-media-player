using Amp.Windows;
using BluDay.Net.DependencyInjection;
using BluDay.Net.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;

namespace Amp;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public sealed partial class App : Application
{
    private ImplementationProvider<Window> _windowFactory;

    private ILogger _logger;

    private IKeyedServiceProvider _rootServiceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        _windowFactory = null!;

        _logger = null!;

        _rootServiceProvider = new ServiceCollection()
            .Add(ConfigureServices)
            .BuildServiceProvider();

        InitializeComponent();
    }

    private void InitializeServices()
    {
        _logger = _rootServiceProvider.GetRequiredService<ILogger<App>>();

        _windowFactory = _rootServiceProvider.GetRequiredService<ImplementationProvider<Window>>();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="e">
    /// Details about the launch request and process.
    /// </param>
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        InitializeServices();

        _windowFactory.GetInstance<MainWindow>().Activate();
    }
}