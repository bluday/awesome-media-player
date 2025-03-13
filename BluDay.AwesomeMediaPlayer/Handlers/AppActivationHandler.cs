namespace BluDay.AwesomeMediaPlayer.Handlers;

/// <summary>
/// Handles the specific activation procedures for the application.
/// </summary>
public sealed class AppActivationHandler : IAppActivationHandler
{
    private readonly IAppWindowService _windowService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppActivationHandler"/> class.
    /// </summary>
    /// <param name="windowService">
    /// The service used to create and manage windows within the running app.
    /// </param>
    public AppActivationHandler(IAppWindowService windowService)
    {
        _windowService = windowService;
    }

    /// <inheritdoc cref="IAppActivationHandler.ActivateAsync(object?)"/>
    public Task ActivateAsync(object? args)
    {
        _windowService
            .CreateWindow<Shell>()
            .Activate();

        return Task.CompletedTask;
    }
}