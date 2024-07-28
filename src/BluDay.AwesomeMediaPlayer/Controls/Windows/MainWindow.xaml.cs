namespace BluDay.AwesomeMediaPlayer.Controls.Windows;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public MainWindowViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();

        ViewModel = viewModel;

        viewModel.SetWindow(this, TitleBar);
    }
}