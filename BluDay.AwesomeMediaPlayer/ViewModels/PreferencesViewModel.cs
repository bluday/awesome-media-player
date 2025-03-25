namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the preferences window and view.
/// </summary>
public sealed partial class PreferencesViewModel : ViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesViewModel"/> class.
    /// </summary>
    public PreferencesViewModel(WeakReferenceMessenger messenger) : base(messenger) { }
}