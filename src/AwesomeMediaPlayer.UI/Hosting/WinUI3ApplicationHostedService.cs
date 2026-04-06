using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace AwesomeMediaPlayer.UI.Hosting;

/// <summary>
/// Represents a service for a WinUI 3 application that is managed by a host.
/// </summary>
public sealed class WinUI3ApplicationHostedService : IHostedService
{
    #region Instance fields
    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    private readonly ILogger _logger;

    private readonly IServiceProvider _rootServiceProvider;
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="WinUI3ApplicationHostedService"/>
    /// class using the specified dependencies.
    /// </summary>
    /// <param name="hostApplicationLifetime">
    /// A service for managing the lifetime of the application.
    /// </param>
    /// <param name="logger">
    /// The logger instance for this type.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Throws if any of the parameters are <c>null</c>.
    /// </exception>
    public WinUI3ApplicationHostedService(
        IHostApplicationLifetime                hostApplicationLifetime,
        IServiceProvider                        rootServiceProvider,
        ILogger<WinUI3ApplicationHostedService> logger)
    {
        ArgumentNullException.ThrowIfNull(hostApplicationLifetime);
        ArgumentNullException.ThrowIfNull(rootServiceProvider);
        ArgumentNullException.ThrowIfNull(logger);

        _hostApplicationLifetime = hostApplicationLifetime;

        _logger = logger;

        _rootServiceProvider = rootServiceProvider;
    }
    #endregion

    #region Instance methods
    private void CreateApplication()
    {
        XamlCheckProcessRequirements();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        Application.Start(_ =>
        {
            var dispatcherQueue = DispatcherQueue.GetForCurrentThread();

            SynchronizationContext.SetSynchronizationContext(
                new DispatcherQueueSynchronizationContext(dispatcherQueue)
            );

            _rootServiceProvider.GetRequiredService<Application>();
        });

        _hostApplicationLifetime.StopApplication();
    }

    /// <inheritdoc cref="IHostedService.StartAsync(CancellationToken)"/>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting the WinUI 3 application host...");

        Thread thread = new(CreateApplication);

        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();

        await Task.CompletedTask;

        _logger.LogInformation("The WinUI 3 application host has been started.");
    }

    /// <inheritdoc cref="IHostedService.StopAsync(CancellationToken)"/>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping the WinUI 3 application host...");

        await Task.CompletedTask;

        _logger.LogInformation("The WinUI 3 application host has been stopped.");
    }
    #endregion

    #region Static methods
    [DllImport("Microsoft.UI.Xaml.dll")]
    internal static extern void XamlCheckProcessRequirements();
    #endregion
}