namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the current media information window.
/// </summary>
public sealed partial class CurrentMediaInformationWindowViewModel : WindowViewModel
{
    #region Properties
    /// <summary>
    /// Gets the current current media information view model instance.
    /// </summary>
    public CurrentMediaInformationViewModel CurrentMediaInformationViewModel { get; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentMediaInformationWindowViewModel"/> class.
    /// </summary>
    /// <param name="currentMediaInformationViewModel">
    /// The view model for the current media information view, as a transient.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public CurrentMediaInformationWindowViewModel(
        CurrentMediaInformationViewModel currentMediaInformationViewModel,
        ResourceLoader                   resourceLoader)
    {
        _defaultConfiguration = GetDefaultConfiguration(resourceLoader);

        CurrentMediaInformationViewModel = currentMediaInformationViewModel;
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
            Title                      = resourceLoader.GetString("CurrentMediaInformationWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(800, 700),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}