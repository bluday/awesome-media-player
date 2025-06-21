using Amp.ViewModels;
using CommunityToolkit.WinUI.UI.Controls;

namespace Amp.Views;

/// <summary>
/// Interaction logic for HelpPage.xaml.
/// </summary>

public sealed partial class HelpPage : Microsoft.UI.Xaml.Controls.Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HelpPage"/> class.
    /// </summary>
    public HelpPage()
    {
        InitializeComponent();
    }

    private void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        if (DataContext is HelpViewModel viewModel)
        {
            viewModel.OnLinkClickedAsync(e);
        }
    }
}