namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for HelpView.xaml
/// </summary>
public sealed partial class HelpView : UserControl
{
    private readonly HelpViewModel _viewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="HelpViewModel"/> instance.
    /// </param>
    public HelpView(HelpViewModel viewModel)
    {
        DataContext = _viewModel = viewModel;

        InitializeComponent();
    }

    private async void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        await _viewModel.OnLinkClickedAsync(e);
    }
}