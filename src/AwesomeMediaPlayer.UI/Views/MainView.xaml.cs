using AwesomeMediaPlayer.UI.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for MainView.xaml.
/// </summary>
public sealed partial class MainView : UserControl
{
    #region Instance properties
    /// <summary>
    /// Gets the view model.
    /// </summary>
    public MainViewModel ViewModel { get; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MainView"/>
    /// class.
    /// </summary>
    public MainView()
    {
        ViewModel = Ioc.Default.GetRequiredService<MainViewModel>();

        InitializeComponent();
    }
    #endregion
}