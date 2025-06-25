namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for CurrentMediaInformationGeneralPage.xaml.
/// </summary>
public sealed partial class CurrentMediaInformationGeneralPage : Microsoft.UI.Xaml.Controls.Page
{
    /// <summary>
    /// Gets or sets the view model instance.
    /// </summary>
    public ViewModels.CurrentMediaInformationGeneralViewModel ViewModel { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentMediaInformationGeneralPage"/> class.
    /// </summary>
    public CurrentMediaInformationGeneralPage()
    {
        InitializeComponent();
    }
}