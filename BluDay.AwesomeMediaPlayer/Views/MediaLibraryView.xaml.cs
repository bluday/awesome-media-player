namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for MediaLibraryView.xaml
/// </summary>
public sealed partial class MediaLibraryView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediaLibraryView"/> class.
    /// </summary>
    public MediaLibraryView() => InitializeComponent();

    private async void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        if (DataContext is MediaLibraryViewModel viewModel)
        {
            await viewModel.OnLinkClickedAsync(e);
        }
    }
}