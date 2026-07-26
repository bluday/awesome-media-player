using AwesomeMediaPlayer.UI.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for AboutView.xaml.
/// </summary>
public sealed partial class AboutView : UserControl
{
    #region Instance properties
    /// <summary>
    /// Gets the view model.
    /// </summary>
    public AboutViewModel ViewModel { get; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="AboutView"/>
    /// class.
    /// </summary>
    public AboutView()
    {
        ViewModel = Ioc.Default.GetRequiredService<AboutViewModel>();

        InitializeComponent();
    }
    #endregion
}