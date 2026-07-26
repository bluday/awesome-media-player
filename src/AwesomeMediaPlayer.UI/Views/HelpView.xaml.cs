using AwesomeMediaPlayer.UI.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for HelpView.xaml.
/// </summary>
public sealed partial class HelpView : UserControl
{
    #region Instance properties
    /// <summary>
    /// Gets the view model.
    /// </summary>
    public HelpViewModel ViewModel { get; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="HelpView"/>
    /// class.
    /// </summary>
    public HelpView()
    {
        ViewModel = Ioc.Default.GetRequiredService<HelpViewModel>();

        InitializeComponent();
    }
    #endregion
}