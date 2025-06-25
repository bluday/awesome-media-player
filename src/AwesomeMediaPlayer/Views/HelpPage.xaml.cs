using AwesomeMediaPlayer.ViewModels;
using CommunityToolkit.WinUI.UI.Controls;

namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for HelpPage.xaml.
/// </summary>
public sealed partial class HelpPage : Microsoft.UI.Xaml.Controls.Page
{
    /// <summary>
    /// Gets or sets the view model instance.
    /// </summary>
    public HelpViewModel ViewModel { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpPage"/> class.
    /// </summary>
    public HelpPage()
    {
        InitializeComponent();
    }

    private void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        if (ViewModel is HelpViewModel viewModel)
        {
            viewModel.OnLinkClickedAsync(e).ConfigureAwait(false);
        }
    }
}