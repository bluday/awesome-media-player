namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for CurrentMediaInformationGeneralView.xaml.
/// </summary>
public sealed partial class CurrentMediaInformationGeneralView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets or sets the view model instance.
    /// </summary>
    public ViewModels.CurrentMediaInformationGeneralViewModel ViewModel { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentMediaInformationGeneralView"/> class.
    /// </summary>
    public CurrentMediaInformationGeneralView()
    {
        InitializeComponent();
    }
}