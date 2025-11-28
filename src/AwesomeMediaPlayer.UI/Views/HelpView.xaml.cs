using AwesomeMediaPlayer.UI.ViewModels;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for HelpView.xaml.
/// </summary>
public sealed partial class HelpView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets the current view model instance.
    /// </summary>
    public HelpViewModel ViewModel => (HelpViewModel)DataContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpView"/> class.
    /// </summary>
    public HelpView()
    {
        InitializeComponent();
    }
}