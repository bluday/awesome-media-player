using Microsoft.UI.Xaml;
using System;
using Windows.Foundation;
using Windows.Graphics;

namespace AwesomeMediaPlayer.UI.Infrastructure.Extensions;

/// <summary>
/// Provides extension methods for <see cref="FrameworkElement"/> instances.
/// </summary>
public static class FrameworkElementExtensions
{
    #region Constants
    /// <summary>
    /// The default bounding box scale factor.
    /// </summary>
    public const double DEFAULT_BOUNDING_BOX_SCALE_FACTOR = 1.0;

    /// <summary>
    /// The "FilledIconUri" string literal.
    /// </summary>
    public const string FilledIconUri = "FilledIconUri";

    /// <summary>
    /// The "RegularIconUri" string literal.
    /// </summary>
    public const string RegularIconUri = "RegularIconUri";

    /// <summary>
    /// The "TargetPage" string literal.
    /// </summary>
    public const string TargetPage = "TargetPage";
    #endregion

    #region Attached properties
    /// <summary>
    /// Identifies the <see cref="FilledIconUri"/> attached property.
    /// </summary>
    public static readonly DependencyProperty FilledIconUriProperty = DependencyProperty.RegisterAttached(
        nameof(FilledIconUri),
        typeof(Uri),
        typeof(FrameworkElement),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="RegularIconUri"/> attached property.
    /// </summary>
    public static readonly DependencyProperty RegularIconUriProperty = DependencyProperty.RegisterAttached(
        RegularIconUri,
        typeof(Uri),
        typeof(FrameworkElement),
        new PropertyMetadata(defaultValue: null)
    );

    /// <summary>
    /// Identifies the <see cref="TargetPage"/> attached property.
    /// </summary>
    public static readonly DependencyProperty TargetPageProperty = DependencyProperty.RegisterAttached(
        TargetPage,
        typeof(Type),
        typeof(FrameworkElement),
        new PropertyMetadata(defaultValue: null)
    );
    #endregion

    #region Attached property getters and setters
    /// <summary>
    /// Gets the <see cref="Uri"/> for the filled icon from the
    /// specified element.
    /// </summary>
    /// <param name="element">
    /// The targeted element to get the image source from.
    /// </param>
    /// <returns>
    /// The set <see cref="Uri"/> or <c>null</c>.
    /// </returns>
    public static Uri? GetFilledIconUri(UIElement element)
    {
        return element.GetValue(FilledIconUriProperty) as Uri;
    }

    /// <summary>
    /// Gets the <see cref="Uri"/> for the regular icon from the
    /// specified element.
    /// </summary>
    /// <param name="element">
    /// The targeted element to get the image source from.
    /// </param>
    /// <returns>
    /// The set <see cref="Uri"/> or <c>null</c>.
    /// </returns>
    public static Uri? GetRegularIconUri(UIElement element)
    {
        return element.GetValue(RegularIconUriProperty) as Uri;
    }

    /// <summary>
    /// Gets the targeted page type from the specified element.
    /// </summary>
    /// <param name="element">
    /// The targeted element to get the targeted page type from.
    /// </param>
    /// <returns>
    /// The targeted page type if set; otherwise <c>null</c>.
    /// </returns>
    public static Type? GetTargetPage(UIElement element)
    {
        return element.GetValue(TargetPageProperty) as Type;
    }

    /// <summary>
    /// Sets the specified filled SVG icon for the specified element.
    /// </summary>
    /// <param name="element">
    /// The targeted element to set the image source for.
    /// </param>
    /// <param name="value">
    /// The SVG image source.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Throws if <paramref name="element"/> is <c>null</c>.
    /// </exception>
    public static void SetFilledIconUri(UIElement element, Uri value)
    {
        ArgumentNullException.ThrowIfNull(element);

        element.SetValue(FilledIconUriProperty, value);
    }

    /// <summary>
    /// Sets the specified regular SVG icon for the specified element.
    /// </summary>
    /// <param name="element">
    /// The targeted element to set the image source for.
    /// </param>
    /// <param name="value">
    /// The SVG image source.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Throws if <paramref name="element"/> is <c>null</c>.
    /// </exception>
    public static void SetRegularIconUri(UIElement element, Uri value)
    {
        ArgumentNullException.ThrowIfNull(element);

        element.SetValue(RegularIconUriProperty, value);
    }

    /// <summary>
    /// Sets the specified page type to target when performing a certain action.
    /// </summary>
    /// <param name="element">
    /// The targeted element to set the target page type for.
    /// </param>
    /// <param name="value">
    /// The targeted page type.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Throws if <paramref name="element"/> is <c>null</c>.
    /// </exception>
    public static void SetTargetPage(UIElement element, Type value)
    {
        ArgumentNullException.ThrowIfNull(element);

        element.SetValue(TargetPageProperty, value);
    }
    #endregion

    #region Extension methods
    /// <summary>
    /// Computes the bounding box of the element in screen coordinates and returns
    /// it as an integer rectangle.
    /// <inheritdoc cref="GetBoundingBox(FrameworkElement, double)"/>
    public static RectInt32 GetBoundingBox(this FrameworkElement source)
    {
        ArgumentNullException.ThrowIfNull(source);

        return source.GetBoundingBox(DEFAULT_BOUNDING_BOX_SCALE_FACTOR);
    }

    /// <summary>
    /// Computes the bounding box of the element in screen coordinates and returns
    /// it as an integer rectangle, scaled by the specified factor.
    /// </summary>
    /// <param name="source">
    /// The <see cref="FrameworkElement"/> whose bounding box is to be calculated.
    /// </param>
    /// <param name="scaleFactor">
    /// The scale factor to apply to the resulting dimensions.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="source"/> is <c>null</c>.
    /// </exception>
    /// <returns>
    /// A <see cref="RectInt32"/> value representing the scaled bounding box of
    /// the element.
    /// </returns>
    public static RectInt32 GetBoundingBox(this FrameworkElement source, double scaleFactor)
    {
        ArgumentNullException.ThrowIfNull(source);

        Rect rect = source
            .TransformToVisual(visual: null)
            .TransformBounds(new Rect(0, 0, source.ActualWidth, source.ActualHeight));

        return new(
            (int)(rect.X * scaleFactor),
            (int)(rect.Y * scaleFactor),
            (int)(rect.Width * scaleFactor),
            (int)(rect.Height * scaleFactor)
        );
    }
    #endregion
}