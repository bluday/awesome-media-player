namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model for <see cref="Shell"/>.
/// </summary>
public sealed partial class ShellViewModel : Net.WinUI3.ViewModels.ShellViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
    /// </summary>
    public ShellViewModel(
        AppNavigationService   appNavigationService,
        WeakReferenceMessenger messenger
    )
        : base(appNavigationService, messenger) { }
}