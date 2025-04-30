namespace BluDay.AwesomeMediaPlayer.Controls.Views;

/// <summary>
/// Interaction logic for AboutView.xaml
/// </summary>
public sealed partial class AboutView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AboutView"/> class.
    /// </summary>
    public AboutView() => InitializeComponent();

    private async void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        if (DataContext is AboutViewModel viewModel)
        {
            await viewModel.OnLinkClickedAsync(e);
        }
    }
}