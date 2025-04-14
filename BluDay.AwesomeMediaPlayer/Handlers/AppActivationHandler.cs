namespace BluDay.AwesomeMediaPlayer.Handlers;

/// <summary>
/// Handles the specific activation procedures for the application.
/// </summary>
public sealed class AppActivationHandler : IAppActivationHandler
{
    private readonly Func<MainWindow> _mainWindowFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppActivationHandler"/> class.
    /// </summary>
    /// <param name="serviceProvider">
    /// The root service provider instance.
    /// </param>
    public AppActivationHandler(IServiceProvider serviceProvider)
    {
        _mainWindowFactory = serviceProvider.GetRequiredService<MainWindow>;
    }

    /// <inheritdoc cref="IAppActivationHandler.ActivateAsync(object?)"/>
    public Task ActivateAsync(object? args)
    {
        _mainWindowFactory().Activate();

        return Task.CompletedTask;
    }
}