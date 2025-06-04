namespace BluDay.AwesomeMediaPlayer.Domain.ViewModels;

/// <summary>
/// Represents the view model for the preferences window.
/// </summary>
public sealed partial class PreferencesWindowViewModel : WindowViewModel
{
    #region Properties
    /// <summary>
    /// Gets the current preferences view model instance.
    /// </summary>
    public PreferencesViewModel PreferencesViewModel { get; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesWindowViewModel"/> class.
    /// </summary>
    /// <param name="preferencesViewModel">
    /// The view model for the preferences view, as a transient.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public PreferencesWindowViewModel(
        PreferencesViewModel preferencesViewModel,
        ResourceLoader       resourceLoader)
    {
        DefaultAppWindowConfiguration = GetDefaultAppWindowConfiguration(resourceLoader);
        DefaultWindowConfiguration    = GetDefaultWindowConfiguration(resourceLoader);

        PreferencesViewModel = preferencesViewModel;
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
            Size     = new SizeInt32((int)(800 * 1.5), (int)(700 * 1.5)),
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
            Title                      = resourceLoader.GetString("PreferencesWindow/Title")
        };
    }
    #endregion
}