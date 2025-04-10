namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for MediaLibraryView.xaml
/// </summary>
public sealed partial class MediaLibraryView : UserControl
{
    private readonly MediaLibraryViewModel _viewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaLibraryView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="MediaLibraryViewModel"/> instance.
    /// </param>
    public MediaLibraryView(MediaLibraryViewModel viewModel)
    {
        DataContext = _viewModel = viewModel;

        InitializeComponent();
    }

    private async void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        await _viewModel.OnLinkClickedAsync(e);
    }
}