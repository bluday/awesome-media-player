using AwesomeMediaPlayer.UI.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for MediaLibraryView.xaml.
/// </summary>
public sealed partial class MediaLibraryView : UserControl
{
    #region Instance properties
    /// <summary>
    /// Gets the view model.
    /// </summary>
    public MediaLibraryViewModel ViewModel { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MediaLibraryView"/>
    /// class.
    /// </summary>
    public MediaLibraryView()
    {
        ViewModel = Ioc.Default.GetRequiredService<MediaLibraryViewModel>();

        InitializeComponent();
    }
    #endregion
}