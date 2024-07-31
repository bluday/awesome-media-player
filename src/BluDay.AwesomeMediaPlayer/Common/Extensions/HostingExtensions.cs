namespace BluDay.AwesomeMediaPlayer.Extensions;

/// <summary>
/// A utility class with method extensions for types in the <see cref="Microsoft.Extensions.Hosting"/> namespace.
/// </summary>
public static class HostingExtensions
{
    [DllImport("Microsoft.UI.Xaml.dll")]
    static extern void XamlCheckProcessRequirements();

    /// <summary>
    /// Starts the application host and instantiates a new <see cref="App"/> instance.
    /// </summary>
    /// <param name="source">
    /// The application host instance.
    /// </param>
    /// <typeparam name="TApp">
    /// The derived <see cref="Application"/> type for the WinUI 3 app.
    /// </typeparam>
    public static void CreateWinui3App<TApp>(this IHost source) where TApp : Application
    {
        XamlCheckProcessRequirements();

        WinRT.ComWrappersSupport.InitializeComWrappers();

        Application.Start(callback =>
        {
            var dispatcherQueue = source.Services.GetRequiredService<DispatcherQueue>();

            SynchronizationContext.SetSynchronizationContext(
                new DispatcherQueueSynchronizationContext(dispatcherQueue)
            );

            source.Services.GetRequiredService<TApp>();
        });
    }
}