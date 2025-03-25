namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for SettingsView.xaml
/// </summary>
public sealed partial class SettingsView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="SettingsViewModel"/> instance.
    /// </param>
    public SettingsView(SettingsViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}