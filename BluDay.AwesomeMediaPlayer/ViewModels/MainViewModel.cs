namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the main view.
/// </summary>
public sealed partial class MainViewModel : ObservableObject
{
    private readonly Func<AboutWindow> _aboutWindowFactory;

    private readonly Func<HelpWindow> _helpWindowFactory;

    #region Properties
    /// <summary>
    /// Gets the media library view model instance.
    /// </summary>
    public MediaLibraryViewModel MediaLibraryViewModel { get; }
    #endregion

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <param name="mediaLibraryViewModel">
    /// A transient <see cref="MediaLibraryViewModel"/> instance.
    /// </param>
    /// <param name="serviceProvider">
    /// The root service provider instance.
    /// </param>
    public MainViewModel(
        MediaLibraryViewModel mediaLibraryViewModel,
        IServiceProvider      serviceProvider)
    {
        _aboutWindowFactory = serviceProvider.GetRequiredService<AboutWindow>;
        _helpWindowFactory  = serviceProvider.GetRequiredService<HelpWindow>;

        MediaLibraryViewModel = mediaLibraryViewModel;
    }

    /// <summary>
    /// Opens the about window.
    /// </summary>
    [RelayCommand]
    public void OpenAboutWindow()
    {
        _aboutWindowFactory().Activate();
    }

    /// <summary>
    /// Opens the help window.
    /// </summary>
    [RelayCommand]
    public void OpenHelpWindow()
    {
        _helpWindowFactory().Activate();
    }

    /// <summary>
    /// Launches a new application shell showing the current-media-information view.
    /// </summary>
    [RelayCommand]
    public void ShowCurrentMediaInformationWindow()
    {
        // TODO: Create and activate a new shell with a different configuration.
    }
}