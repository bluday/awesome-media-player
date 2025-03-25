namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for PreferencesView.xaml
/// </summary>
public sealed partial class PreferencesView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="PreferencesViewModel"/> instance.
    /// </param>
    public PreferencesView(PreferencesViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}