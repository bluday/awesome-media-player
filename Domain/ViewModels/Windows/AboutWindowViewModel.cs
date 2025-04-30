namespace BluDay.AwesomeMediaPlayer.Domain.ViewModels;

/// <summary>
/// Represents the view model class for the about window.
/// </summary>
public sealed partial class AboutWindowViewModel : WindowViewModel
{
    #region Properties
    /// <summary>
    /// Gets the current about view model instance
    /// </summary>
    public AboutViewModel AboutViewModel { get; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutWindowViewModel"/> class.
    /// </summary>
    /// <param name="aboutViewModel">
    /// The view model for the about view, as a transient.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public AboutWindowViewModel(AboutViewModel aboutViewModel, ResourceLoader resourceLoader)
    {
        _defaultConfiguration = GetDefaultConfiguration(resourceLoader);

        AboutViewModel = aboutViewModel;
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
            Title                      = resourceLoader.GetString("AboutWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(750, 380),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}