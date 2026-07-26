using AwesomeMediaPlayer.UI.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace AwesomeMediaPlayer.UI.Views;

/// <summary>
/// Interaction logic for CurrentMediaInformationGeneralView.xaml.
/// </summary>
public sealed partial class CurrentMediaInformationGeneralView : UserControl
{
    #region Instance properties
    /// <summary>
    /// Gets the view model.
    /// </summary>
    public CurrentMediaInformationGeneralViewModel ViewModel { get; }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="CurrentMediaInformationGeneralView"/>
    /// class.
    /// </summary>
    public CurrentMediaInformationGeneralView()
    {
        ViewModel = Ioc.Default.GetRequiredService<CurrentMediaInformationGeneralViewModel>();

        InitializeComponent();
    }
    #endregion
}