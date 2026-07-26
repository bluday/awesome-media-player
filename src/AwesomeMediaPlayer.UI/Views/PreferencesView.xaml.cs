using AwesomeMediaPlayer.UI.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for PreferencesView.xaml.
/// </summary>
public sealed partial class PreferencesView : UserControl
{
    #region Instance properties
    /// <summary>
    /// Gets the view model.
    /// </summary>
    public PreferencesViewModel ViewModel { get; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="PreferencesView"/>
    /// class.
    /// </summary>
    public PreferencesView()
    {
        ViewModel = Ioc.Default.GetRequiredService<PreferencesViewModel>();

        InitializeComponent();
    }
    #endregion
}