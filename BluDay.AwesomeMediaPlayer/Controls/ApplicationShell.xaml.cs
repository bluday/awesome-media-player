namespace BluDay.AwesomeMediaPlayer.Windows;

/// <summary>
/// Represents a customizable shell window that hosts and manages a view model.
/// This window can be used independently or within a Frame for navigation.
/// </summary>
public sealed partial class ApplicationShell : Window, IBluWindow
{
    private readonly Lazy<MainView> _mainView;

    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public ApplicationShellViewModel ViewModel { get; }

    /// <inheritdoc cref="IBluWindow.Id"/>
    public ulong Id => AppWindow.Id!.Value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationShell"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    /// <param name="serviceProvider">
    /// The root service provider.
    /// </param>
    public ApplicationShell(
        ApplicationShellViewModel viewModel,
        MainView                  mainView,
        ResourceLoader            resourceLoader,
        IServiceProvider          serviceProvider)
    {
        _mainView = new Lazy<MainView>(
            serviceProvider.GetRequiredService<MainView>
        );

        ViewModel = viewModel;

        InitializeComponent();

        viewModel.DefaultConfiguration = GetDefaultConfiguration(resourceLoader);

        viewModel.TitleBarControl = AppTitleBar;

        viewModel.SetWindow(this);

        ViewContentControl.Content = _mainView.Value;
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
            Title                      = resourceLoader.GetString("ApplicationShell/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(1000, 800),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}