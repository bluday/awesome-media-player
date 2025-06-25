using AwesomeMediaPlayer.ViewModels;
using CommunityToolkit.WinUI.UI.Controls;

namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for AboutPage.xaml.
/// </summary>
public sealed partial class AboutPage : Microsoft.UI.Xaml.Controls.Page
{
    /// <summary>
    /// Gets or sets the view model instance.
    /// </summary>
    public AboutViewModel ViewModel { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutPage"/> class.
    /// </summary>
    public AboutPage()
    {
        InitializeComponent();
    }

    private void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        if (ViewModel is AboutViewModel viewModel)
        {
            viewModel.OnLinkClickedAsync(e).ConfigureAwait(false);
        }
    }
}