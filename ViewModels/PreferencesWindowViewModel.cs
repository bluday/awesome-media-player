namespace BluDay.AwesomeMediaPlayer.ViewModels;

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
        _defaultConfiguration = GetDefaultConfiguration(resourceLoader);

        PreferencesViewModel = preferencesViewModel;
    }

    /// <summary>
    /// Gets default configuration presets for this window.
    /// </summary>
    /// <param name="resourceLoader">
    /// An instance of type <see cref="ResourceLoader"> for loading resources, such as titles
    /// and icon paths.
    /// </param>
    /// <returns>
    /// The configuration instance.
    /// </returns>
    public static WindowConfiguration GetDefaultConfiguration(ResourceLoader resourceLoader)
    {
        return new()
        {
            Title                      = resourceLoader.GetString("PreferencesWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(800, 700),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}