using AwesomeMediaPlayer.UI.ViewModels;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for CurrentMediaInformationGeneralView.xaml.
/// </summary>
public sealed partial class CurrentMediaInformationGeneralView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets the current view model instance.
    /// </summary>
    public CurrentMediaInformationGeneralViewModel ViewModel => (CurrentMediaInformationGeneralViewModel)DataContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentMediaInformationGeneralView"/> class.
    /// </summary>
    public CurrentMediaInformationGeneralView()
    {
        InitializeComponent();
    }
}