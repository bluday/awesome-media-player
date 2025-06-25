namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for PreferencesPage.xaml.
/// </summary>
public sealed partial class PreferencesPage : Microsoft.UI.Xaml.Controls.Page
{
    /// <summary>
    /// Gets or sets the view model instance.
    /// </summary>
    public ViewModels.PreferencesViewModel ViewModel { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesPage"/> class.
    /// </summary>
    public PreferencesPage()
    {
        InitializeComponent();
    }
}