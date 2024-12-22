namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
/// <inheritdoc/>
public sealed partial class Shell : Window, IBluNavigableWindow
{
    private readonly Lazy<MainView> _mainView;

    public ViewNavigator ViewNavigator => ViewModel.ViewNavigator;

    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public ShellViewModel ViewModel { get; }

    public ulong Id => AppWindow.Id!.Value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
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
    public Shell(
        ShellViewModel   viewModel,
        MainView         mainView,
        ResourceLoader   resourceLoader,
        IServiceProvider serviceProvider)
    {
        _mainView = new Lazy<MainView>(
            serviceProvider.GetRequiredService<MainView>
        );

        ViewModel = viewModel;

        InitializeComponent();

        UpdateViewModelWindowTarget(resourceLoader);

        ViewContentControl.Content = _mainView.Value;
    }

    private void UpdateViewModelWindowTarget(ResourceLoader resourceLoader)
    {
        ShellViewModel viewModel = ViewModel;

        viewModel.DefaultConfiguration = GetDefaultConfiguration(resourceLoader);

        viewModel.TitleBarControl = AppTitleBar;

        viewModel.SetWindow(this);
    }

    public void ApplyDefaultConfiguration()
    {
        ViewModel.ApplyDefaultConfiguration();
    }

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
            Title                      = resourceLoader.GetString("MainWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(1000, 800),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}