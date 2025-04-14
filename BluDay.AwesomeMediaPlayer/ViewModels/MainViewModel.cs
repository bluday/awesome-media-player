namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the main view.
/// </summary>
public sealed partial class MainViewModel : ObservableObject
{
    private readonly Func<AboutWindow> _aboutWindowFactory;

    private readonly Func<HelpWindow> _helpWindowFactory;

    private readonly Func<PreferencesWindow> _preferencesWindowFactory;

    private readonly Func<CurrentMediaInformationWindow> _currentMediaInformationWindowFactory;

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
    /// A transient media library view model instance.
    /// </param>
    /// <param name="serviceProvider">
    /// The root service provider instance.
    /// </param>
    public MainViewModel(
        MediaLibraryViewModel mediaLibraryViewModel,
        IServiceProvider      serviceProvider)
    {
        _aboutWindowFactory                   = serviceProvider.GetRequiredService<AboutWindow>;
        _helpWindowFactory                    = serviceProvider.GetRequiredService<HelpWindow>;
        _preferencesWindowFactory             = serviceProvider.GetRequiredService<PreferencesWindow>;
        _currentMediaInformationWindowFactory = serviceProvider.GetRequiredService<CurrentMediaInformationWindow>;

        MediaLibraryViewModel = mediaLibraryViewModel;
    }

    /// <summary>
    /// Activates a new <see cref="AboutWindow"/> instance and brings it to the foreground.
    /// </summary>
    [RelayCommand]
    public void OpenAboutWindow()
    {
        _aboutWindowFactory().Activate();
    }

    /// <summary>
    /// Activates a new <see cref="HelpWindow"/> instance and brings it to the foreground.
    /// </summary>
    [RelayCommand]
    public void OpenHelpWindow()
    {
        _helpWindowFactory().Activate();
    }

    /// <summary>
    /// Activates a new <see cref="PreferencesWindow"/> instance and brings it to the foreground.
    /// </summary>
    [RelayCommand]
    public void OpenPreferencesWindow()
    {
        _preferencesWindowFactory().Activate();
    }

    /// <summary>
    /// Activates a new <see cref="CurrentMediaInformationWindow"/> instance and brings it to the
    /// foreground.
    /// </summary>
    [RelayCommand]
    public void OpenCurrentMediaInformationWindow()
    {
        _currentMediaInformationWindowFactory().Activate();
    }
}