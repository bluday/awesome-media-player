namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for the main window.
/// </summary>
public sealed partial class MainWindowViewModel : ShellViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">
    /// The navigation service.
    /// </param>
    /// <param name="messenger">
    /// The messaging service.
    /// </param>
    public MainWindowViewModel(
        IAppNavigationService  navigationService,
        WeakReferenceMessenger messenger
    )
        : base(navigationService, messenger) { }
}