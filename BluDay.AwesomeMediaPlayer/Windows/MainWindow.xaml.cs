namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// Represents a customizable shell window that hosts and manages a view model.
/// This window can be used independently or within a Frame for navigation.
/// </summary>
public sealed partial class MainWindow : Window
{
    private readonly MainView _mainView;

    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public MainWindowViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    /// <param name="mainView">
    /// The main view. Temporary.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public MainWindow(
        MainWindowViewModel viewModel,
        MainView            mainView,
        ResourceLoader      resourceLoader)
    {
        _mainView = mainView;

        ViewModel = viewModel;

        InitializeComponent();

        /*
        viewModel.DefaultConfiguration = GetDefaultConfiguration(resourceLoader);

        viewModel.TitleBarControl = AppTitleBar;

        viewModel.SetWindow(this);
        */
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