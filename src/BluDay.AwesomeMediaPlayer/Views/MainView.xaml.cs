namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for MainView.xaml.
/// </summary>
public sealed partial class MainView : View
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    /// <param name="serviceProvider">
    /// Temporary.
    /// </param>
    public MainView(MainViewModel viewModel, IServiceProvider serviceProvider) : base(viewModel)
    {
        InitializeComponent();

        viewModel.SetNavigationView(NavigationView);

        ViewContentControl.Content = serviceProvider.GetService<SettingsView>();
    }
}