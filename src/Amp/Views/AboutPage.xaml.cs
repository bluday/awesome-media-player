using Amp.ViewModels;
using CommunityToolkit.WinUI.UI.Controls;

namespace Amp.Views;

/// <summary>
/// Interaction logic for AboutPage.xaml.
/// </summary>
public sealed partial class AboutPage : Microsoft.UI.Xaml.Controls.Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AboutPage"/> class.
    /// </summary>
    public AboutPage()
    {
        InitializeComponent();
    }

    private void MarkdownTextBlock_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        if (DataContext is AboutViewModel viewModel)
        {
            viewModel.OnLinkClickedAsync(e);
        }
    }
}