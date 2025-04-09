namespace BluDay.AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for LibraryView.xaml
/// </summary>
public sealed partial class LibraryView : UserControl
{
    private readonly LibraryViewModel _viewModel;

    /// <summary>
    /// Initializes a new instance of the <see cref="LibraryView"/> class.
    /// </summary>
    /// <param name="viewModel">
    /// A transient <see cref="LibraryViewModel"/> instance.
    /// </param>
    public LibraryView(LibraryViewModel viewModel)
    {
        DataContext = _viewModel = viewModel;

        InitializeComponent();
    }

    private async void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        await _viewModel.OnLinkClickedAsync(e);
    }
}