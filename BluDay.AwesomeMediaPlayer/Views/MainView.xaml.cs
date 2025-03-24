namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Represents the interaction logic for the main view.
/// </summary>
public sealed partial class MainView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="MainViewModel"/> instance.
    /// </param>
    public MainView(MainViewModel viewModel)
    {
        DataContext = viewModel;

        InitializeComponent();
    }
}