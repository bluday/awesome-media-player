using AwesomeMediaPlayer.Data.ViewModels;

namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for MediaLibraryView.xaml.
/// </summary>
public sealed partial class MediaLibraryView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets the current view model instance.
    /// </summary>
    public MediaLibraryViewModel ViewModel => (MediaLibraryViewModel)DataContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaLibraryView"/> class.
    /// </summary>
    public MediaLibraryView()
    {
        InitializeComponent();
    }
}