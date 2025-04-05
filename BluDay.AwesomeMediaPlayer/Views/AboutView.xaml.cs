namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for AboutView.xaml
/// </summary>
public sealed partial class AboutView : UserControl
{
    private readonly AboutViewModel _viewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="AboutViewModel"/> instance.
    /// </param>
    public AboutView(AboutViewModel viewModel)
    {
        DataContext = _viewModel = viewModel;

        InitializeComponent();
    }

    private async void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        await _viewModel.OnLinkClickedAsync(e);
    }
}