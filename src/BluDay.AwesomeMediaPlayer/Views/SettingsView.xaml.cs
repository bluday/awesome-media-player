namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for SettingsView.xaml.
/// </summary>
public sealed partial class SettingsView : View
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsView"/> class.
    /// </summary>
    public SettingsView(SettingsViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();
    }
}