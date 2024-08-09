namespace BluDay.AwesomeMediaPlayer.Controls;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
/// <inheritdoc/>
public sealed partial class Shell : Window, IBluNavigableWindow
{
    public ViewNavigator ViewNavigator => ViewModel.ViewNavigator;

    /// <summary>
    /// Gets the view model instance.
    /// </summary>
    public ShellViewModel ViewModel { get; }

    public ulong Id => AppWindow.Id!.Value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Shell"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// The view model instance.
    /// </param>
    public Shell(ShellViewModel viewModel, MainView mainView)
    {
        ViewModel = viewModel;

        InitializeComponent();

        viewModel.SetWindow(this);

        viewModel.TitleBarControl = AppTitleBar;

        ViewContentControl.Content = mainView;
    }

    public void Resize(int width, int height)
    {
        ViewModel.Resize(width, height);
    }
}