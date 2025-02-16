namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the main view.
/// </summary>
public sealed partial class MainViewModel : ViewModel
{
    private readonly IAppWindowService _windowService;

    private readonly ResourceLoader _resourceLoader;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <param name="windowService">
    /// The app window service instance.
    /// </param>
    public MainViewModel(
        IAppWindowService      windowService,
        ResourceLoader         resourceLoader,
        WeakReferenceMessenger messenger
    )
        : base(messenger)
    {
        _windowService = windowService;

        _resourceLoader = resourceLoader;
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