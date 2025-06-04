namespace BluDay.AwesomeMediaPlayer.Domain.ViewModels;

/// <summary>
/// Represents the view model for the main window.
/// </summary>
public sealed partial class MainWindowViewModel : WindowViewModel
{
    #region Properties
    /// <summary>
    /// Gets the current main view model instance.
    /// </summary>
    public MainViewModel MainViewModel { get; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="mainViewModel">
    /// The view model for the main view, as a transient.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public MainWindowViewModel(MainViewModel mainViewModel, ResourceLoader resourceLoader)
    {
        DefaultAppWindowConfiguration = GetDefaultAppWindowConfiguration(resourceLoader);
        DefaultWindowConfiguration    = GetDefaultWindowConfiguration(resourceLoader);

        mainViewModel.CloseWindowCommand = CloseWindowCommand;

        MainViewModel = mainViewModel;
    }
    #endregion

    #region Commands
    /// <summary>
    /// Closes the current window.
    /// </summary>
    [RelayCommand]
    public void CloseWindow()
    {
        Close();
    }
    #endregion

    #region Static configuration methods
    /// <summary>
    /// Gets default configuration for the <see cref="AppWindow"/> instance.
    /// </summary>
    /// <param name="resourceLoader">
    /// An instance of type <see cref="ResourceLoader"> for loading resources, such as titles
    /// and icon paths.
    /// </param>
    /// <returns>
    /// The configuration instance.
    /// </returns>
    public static AppWindowConfiguration GetDefaultAppWindowConfiguration(ResourceLoader resourceLoader)
    {
        return new()
        {
            IconPath = resourceLoader.GetString("AppIconPath/64x64"),
            Size     = new SizeInt32((int)(1000 * 1.5), (int)(800 * 1.5)),
        };
    }

    /// <summary>
    /// Gets default configuration for the window.
    /// </summary>
    /// <param name="resourceLoader">
    /// An instance of type <see cref="ResourceLoader"> for loading resources, such as titles
    /// and icon paths.
    /// </param>
    /// <returns>
    /// The configuration instance.
    /// </returns>
    public static WindowConfiguration GetDefaultWindowConfiguration(ResourceLoader resourceLoader)
    {
        return new()
        {
            ExtendsContentIntoTitleBar = true,
            Title                      = resourceLoader.GetString("MainWindow/Title")
        };
    }
    #endregion
}