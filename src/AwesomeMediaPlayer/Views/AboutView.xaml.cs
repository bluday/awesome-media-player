using AwesomeMediaPlayer.ViewModels;
using CommunityToolkit.WinUI.UI.Controls;

namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for AboutView.xaml.
/// </summary>
public sealed partial class AboutView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets or sets the view model instance.
    /// </summary>
    public AboutViewModel ViewModel { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="AboutView"/> class.
    /// </summary>
    public AboutView()
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