using AwesomeMediaPlayer.ViewModels;
using CommunityToolkit.WinUI.UI.Controls;

namespace AwesomeMediaPlayer.Views;

/// <summary>
/// Interaction logic for HelpView.xaml.
/// </summary>
public sealed partial class HelpView : Microsoft.UI.Xaml.Controls.UserControl
{
    /// <summary>
    /// Gets or sets the view model instance.
    /// </summary>
    public HelpViewModel ViewModel { get; set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="HelpView"/> class.
    /// </summary>
    public HelpView()
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