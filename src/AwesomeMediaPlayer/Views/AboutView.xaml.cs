using AwesomeMediaPlayer.Data.ViewModels;

namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for AboutView.xaml.
/// </summary>
public sealed partial class AboutView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets the current view model instance.
    /// </summary>
    public AboutViewModel ViewModel => (AboutViewModel)DataContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutView"/> class.
    /// </summary>
    public AboutView()
    {
        InitializeComponent();
    }
}