namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Temporary.
/// </summary>
public sealed partial class AboutWindow : Window, IBluWindow
{
    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public ShellViewModel ViewModel { get; }

    /// <inheritdoc cref="IBluWindow.Id"/>
    public ulong Id
    {
        get => AppWindow.Id!.Value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpWindow"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    /// <param name="aboutView">
    /// The about view. Temporary.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public AboutWindow(ShellViewModel viewModel, AboutView aboutView, ResourceLoader resourceLoader)
    {
        ViewModel = viewModel;

        InitializeComponent();

        viewModel.DefaultConfiguration = GetDefaultConfiguration(resourceLoader);

        viewModel.TitleBarControl = AppTitleBar;

        viewModel.SetWindow(this);

        ViewContentControl.Content = aboutView;
    }

    /// <inheritdoc cref="IBluWindow.Resize(int, int)"/>
    public void Resize(int width, int height)
    {
        ViewModel.Resize(width, height);
    }

    /// <summary>
    /// Gets default configuration presets for this window.
    /// </summary>
    /// <param name="resourceLoader">
    /// An instance of type <see cref="ResourceLoader"> for loading resources, such as titles and icon paths.
    /// </param>
    /// <returns>
    /// The configuration instance.
    /// </returns>
    public static WindowConfiguration GetDefaultConfiguration(ResourceLoader resourceLoader)
    {
        return new()
        {
            Title                      = "About",
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(750, 380),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}