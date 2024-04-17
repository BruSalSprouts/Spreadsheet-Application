// <copyright file="ColorConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Spreadsheet_Bruno_SanchezParra.Converters;

/// <summary>
/// Basic ColorConverter class. Was in use for a bit.
/// </summary>
public class ColorConverter : IValueConverter
{
    /// <summary>
    /// Converts an object of RowViewModel to another type.
    /// </summary>
    /// <param name="value">object.</param>
    /// <param name="targetType">Type.</param>
    /// <param name="parameter">object?.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns>potentially null object.</returns>
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is uint sourceColor && targetType.IsAssignableTo(typeof(IBrush)))
        {
            return new SolidColorBrush(sourceColor);
        }

        // converter used for the wrong type
        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    /// <summary>
    /// Method to convert from the new type back to list of RowViewModels.
    /// </summary>
    /// <param name="value">object.</param>
    /// <param name="targetType">Type.</param>
    /// <param name="parameter">object?.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns>potentially null object.</returns>
    /// <exception cref="NotImplementedException">It's not needed here.</exception>
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}