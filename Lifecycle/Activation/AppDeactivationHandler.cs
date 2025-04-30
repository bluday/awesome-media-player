namespace BluDay.AwesomeMediaPlayer.Lifecycle.Activation;

/// <summary>
/// Handles the specific deactivation procedures for the application.
/// </summary>
public sealed class AppDeactivationHandler : IAppDeactivationHandler
{
    private readonly IAppWindowService _windowService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AppDeactivationHandler"/> class.
    /// </summary>
    /// <param name="windowService">
    /// The service used to create and manage windows within the running app.
    /// </param>
    public AppDeactivationHandler(IAppWindowService windowService)
    {
        _windowService = windowService;
    }

    /// <inheritdoc cref="IAppDeactivationHandler.DeactivateAsync()"/>
    public Task DeactivateAsync()
    {
        // TODO: Deactivate the application.

        return Task.CompletedTask;
    }
}