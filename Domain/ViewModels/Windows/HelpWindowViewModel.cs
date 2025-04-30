namespace BluDay.AwesomeMediaPlayer.Domain.ViewModels;

/// <summary>
/// Represents the view model class for the help window.
/// </summary>
public sealed partial class HelpWindowViewModel : WindowViewModel
{
    #region Properties
    /// <summary>
    /// Gets the current help view model instance.
    /// </summary>
    public HelpViewModel HelpViewModel { get; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpWindowViewModel"/> class.
    /// </summary>
    /// <param name="helpViewModel">
    /// The view model for the help view, as a transient.
    /// </param>
    /// <param name="resourceLoader">
    /// The application resource loader.
    /// </param>
    public HelpWindowViewModel(HelpViewModel helpViewModel, ResourceLoader resourceLoader)
    {
        _defaultConfiguration = GetDefaultConfiguration(resourceLoader);

        helpViewModel.CloseWindowCommand = CloseWindowCommand;

        HelpViewModel = helpViewModel;
    }

    /// <summary>
    /// Closes the current window.
    /// </summary>
    [RelayCommand]
    public void CloseWindow()
    {
        Close();
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
            Title                      = resourceLoader.GetString("HelpWindow/Title"),
            ExtendsContentIntoTitleBar = true,
            IconPath                   = resourceLoader.GetString("AppIconPath/64x64"),
            Size                       = new SizeInt32(600, 600),
            Alignment                  = ContentAlignment.MiddleCenter
        };
    }
}