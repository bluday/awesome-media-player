namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for HelpView.xaml
/// </summary>
public sealed partial class HelpView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HelpView"/> class.
    /// </summary>
    public HelpView() => InitializeComponent();

    private async void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        if (DataContext is HelpViewModel viewModel)
        {
            await viewModel.OnLinkClickedAsync(e);
        }
    }
}