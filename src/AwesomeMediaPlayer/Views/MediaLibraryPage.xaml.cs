namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for MediaLibraryPage.xaml.
/// </summary>
public sealed partial class MediaLibraryPage : Microsoft.UI.Xaml.Controls.Page
{
    /// <summary>
    /// Gets or sets the view model instance.
    /// </summary>
    public ViewModels.MediaLibraryViewModel ViewModel { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaLibraryPage"/> class.
    /// </summary>
    public MediaLibraryPage()
    {
        InitializeComponent();
    }
}