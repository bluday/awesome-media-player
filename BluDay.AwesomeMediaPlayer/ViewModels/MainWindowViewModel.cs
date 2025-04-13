namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the app shell.
/// </summary>
public sealed partial class MainWindowViewModel : IBluWindow
{
    private Window _window;

    private readonly ResourceLoader _resourceLoader;

    #region Properties
    /// <inheritdoc cref="IBluWindow.Id"/>
    public ulong Id
    {
        get => _window.AppWindow.Id.Value;
    }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public MainWindowViewModel(ResourceLoader resourceLoader)
    {
        _window = null!;

        _resourceLoader = resourceLoader;
    }

    /// <summary>
    /// Gets default configuration presets for this window.
    /// </summary>
    /// <returns>
    /// The configuration instance.
    /// </returns>
    public WindowConfiguration GetDefaultConfiguration()
    {
        return new()
        {
            Title                      = _resourceLoader.GetString("MainWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = _resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(1000, 800),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }

    /// <inheritdoc cref="IBluWindow.Activate()"/>
    public void Activate()
    {
        _window.Activate();
    }

    /// <inheritdoc cref="IBluWindow.Close()"/>
    public void Close()
    {
        _window.Close();
    }

    /// <inheritdoc cref="IBluWindow.Resize(int, int)"/>
    public void Resize(int width, int height)
    {
        _window.AppWindow.Resize(new SizeInt32(width, height));
    }

    /// <summary>
    /// Assigns the specified window instance to be the target for operations.
    /// </summary>
    /// <param name="window">
    /// The window instance to be set as the active target.
    /// </param>
    /// <remarks>
    /// Use this method to switch the targeted window for subsequent operations.
    /// </remarks>
    public void SetWindow(Window window)
    {
        _window = window;

        // TODO: Apply default configuration to the targeted window.
    }
}