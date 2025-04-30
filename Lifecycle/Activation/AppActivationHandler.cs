namespace BluDay.AwesomeMediaPlayer.Lifecycle.Activation;

/// <summary>
/// Handles the specific activation procedures for the application.
/// </summary>
public sealed class AppActivationHandler : IAppActivationHandler
{
    private readonly ImplementationProvider<Window> _windowFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppActivationHandler"/> class.
    /// </summary>
    /// <param name="windowFactory">
    /// The window factory.
    /// </param>
    public AppActivationHandler(ImplementationProvider<Window> windowFactory)
    {
        _windowFactory = windowFactory;
    }

    /// <inheritdoc cref="IAppActivationHandler.ActivateAsync(object?)"/>
    public Task ActivateAsync(object? args)
    {
        var window = (MainWindow)_windowFactory.GetInstance(typeof(MainWindow));

        window.Activate();

        return Task.CompletedTask;
    }
}