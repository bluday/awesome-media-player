namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public sealed partial class MainView : UserControl
{
    private readonly Lazy<SettingsView> _settingsView;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="MainViewModel"/> instance.
    /// </param>
    public MainView(MainViewModel viewModel, IServiceProvider serviceProvider)
    {
        _settingsView = new Lazy<SettingsView>(serviceProvider.GetRequiredService<SettingsView>);

        DataContext = viewModel;

        InitializeComponent();
    }

    private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.IsSettingsInvoked)
        {
            ViewContentControl.Content = _settingsView.Value;

            return;
        }

        /*
        string? viewName = ((FrameworkElement)args.InvokedItemContainer)?.Tag as string;

        if (viewName is nameof(UserView))
        {
            ViewContentControl.Content = _userView.Value;
        }
        */
    }
}