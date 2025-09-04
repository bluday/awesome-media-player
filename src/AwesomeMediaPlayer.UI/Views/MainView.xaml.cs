using AwesomeMediaPlayer.Data.ViewModels;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for MainView.xaml.
/// </summary>
public sealed partial class MainView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets the current view model instance.
    /// </summary>
    public MainViewModel ViewModel => (MainViewModel)DataContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    public MainView()
    {
        InitializeComponent();
    }
}