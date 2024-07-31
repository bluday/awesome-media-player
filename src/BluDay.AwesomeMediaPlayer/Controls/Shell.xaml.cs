namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class Shell : Window
{
    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public ShellViewModel ViewModel { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    /// <param name="serviceProvider">
    /// Temporary.
    /// </param>
    public Shell(ShellViewModel viewModel, IServiceProvider serviceProvider)
    {
        InitializeComponent();

        ViewModel = viewModel;

        viewModel.SetShell(this, TitleBar);

        ViewContentControl.Content = serviceProvider.GetService<MainView>();
    }
}