namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for MainView.xaml.
/// </summary>
public sealed partial class MainView : View
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    public MainView(MainViewModel viewModel) : base(viewModel)
    {
        InitializeComponent();

        viewModel.SetNavigationView(NavigationView);

        SettingsView settingsView = new(new SettingsViewModel(WeakReferenceMessenger.Default));

        ViewContentControl.Content = settingsView;
    }
}