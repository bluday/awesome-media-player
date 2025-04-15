namespace BluDay.AwesomeMediaPlayer.ViewModels;

/// <summary>
/// Represents the view model class for the help view.
/// </summary>
public sealed partial class HelpViewModel : ObservableObject
{
    #region Properties
    /// <summary>
    /// Gets the raw Markdown text.
    /// </summary>
    public string Text { get; } = GetRawMarkdownText();

    /// <summary>
    /// Gets or sets the close window command.
    /// </summary>
    public ICommand? CloseWindowCommand { get; set; }
    #endregion

    /// <summary>
    /// Handles the link-clicked event by launching the provided URI.
    /// </summary>
    /// <param name="sender">
    /// The source of the event (typically the control that triggered it).
    /// </param>
    /// <param name="e">
    /// Contains the link that was clicked.
    /// </param>
    public async Task OnLinkClickedAsync(LinkClickedEventArgs e)
    {
        await Launcher.LaunchUriAsync(new Uri(e.Link));
    }

    public static string GetRawMarkdownText()
    {
        return @"# Welcome to VLC Media Player Help

##### Documentation

You can find VLC documentation on VideoLAN's [wiki](https://wiki.videolan.org) website.

If you are a newcomer to VLC Media Player, please read the [Introduction to VLC Media Player](https://wiki.videolan.org/Documentation:Introduction/).

You will find some information on how to use the player in the [How to Play Files with VLC Media Player](https://wiki.videolan.org/Documentation:Play/) document.

For all the saving, converting, transcoding, encoding, muxing, and streaming tasks, you should find useful information in the [Streaming Documentation](https://wiki.videolan.org/Documentation:Streaming/).

If you are unsure about terminology, please consult the [knowledge base](https://wiki.videolan.org/Documentation/Glossary/).

To understand the main keyboard shortcuts, read the [shortcuts page](https://wiki.videolan.org/Shortcuts/).

##### Help

Before asking any questions, please refer to the [FAQ](https://wiki.videolan.org/Frequently_Asked_Questions/).

You might then get (and give) help on the [Forums](https://forum.videolan.org/), the [mailing lists](https://www.videolan.org/support/lists.html), or our IRC channel (#videolan on [irc.freenode.net](https://webchat.freenode.net/)).

##### Contribute to the Project

You can help the VideoLAN project by giving some of your time to:

- Help the community
- Design skins
- Translate the documentation
- Test and code

You can also give funds and materials to help us. And of course, you can **promote** VLC Media Player.
";
    }
}