namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Temporary.
/// </summary>
public sealed partial class HelpWindow : Window, IBluWindow
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
    /// <param name="helpView">
    /// The help view. Temporary.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public HelpWindow(ShellViewModel viewModel, HelpView helpView, ResourceLoader resourceLoader)
    {
        ViewModel = viewModel;

        InitializeComponent();

        viewModel.DefaultConfiguration = GetDefaultConfiguration(resourceLoader);

        viewModel.TitleBarControl = AppTitleBar;

        viewModel.SetWindow(this);

        ViewContentControl.Content = helpView;
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
            Title                      = "Help",
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(600, 600),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}