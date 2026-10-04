using AwesomeMediaPlayer.UI.ViewModels;

using Microsoft.UI.Xaml.Controls;

using System;

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

    #region Instance constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="HelpView"/>
    /// class using the specified view model.
    /// </summary>
    /// <param name="viewModel">
    /// The view model.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="viewModel"/> is <see langword="null"/>.
    /// </exception>
    public HelpView(HelpViewModel viewModel)
    {
        ArgumentNullException.ThrowIfNull(viewModel);

        ViewModel = viewModel;

        InitializeComponent();
    }
    #endregion
}