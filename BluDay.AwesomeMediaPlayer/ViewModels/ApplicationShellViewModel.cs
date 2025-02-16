namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for an application shell.
/// </summary>
public sealed partial class ApplicationShellViewModel : ShellViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationShellViewModel"/> class.
    /// </summary>
    /// <param name="navigationService">
    /// The navigation service.
    /// </param>
    /// <param name="messenger">
    /// The messaging service.
    /// </param>
    public ApplicationShellViewModel(
        IAppNavigationService  navigationService,
        WeakReferenceMessenger messenger
    )
        : base(navigationService, messenger) { }
}