using AwesomeMediaPlayer.Data.ViewModels;

namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for PreferencesView.xaml.
/// </summary>
public sealed partial class PreferencesView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets the current view model instance.
    /// </summary>
    public PreferencesViewModel ViewModel => (PreferencesViewModel)DataContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesView"/> class.
    /// </summary>
    public PreferencesView()
    {
        InitializeComponent();
    }
}