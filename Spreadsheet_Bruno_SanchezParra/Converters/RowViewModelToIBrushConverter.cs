// <copyright file="RowViewModelToIBrushConverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra.Converters;

/// <summary>
/// RowViewModelToIBrushConverter class.
/// </summary>
public class RowViewModelToIBrushConverter : IValueConverter
{
    /// <summary>
    /// Instance of the class.
    /// </summary>
    public static readonly RowViewModelToIBrushConverter Instance = new ();

    private RowViewModel? currentRow;
    private int cellCounter;

    /// <summary>
    /// Converts an object of RowViewModel to ColorBrush to give it colors.
    /// </summary>
    /// <param name="value">object.</param>
    /// <param name="targetType">Type.</param>
    /// <param name="parameter">object?.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns>potentially null object.</returns>
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // if the converter used for the wrong type throw an exception
        if (value is not RowViewModel row)
        {
            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        // NOTE: Rows are rendered from column 0 to n and in order
        if (this.currentRow != row)
        {
            this.currentRow = row;
            this.cellCounter = 0;
        }

        var brush = this.currentRow.Cells[this.cellCounter].IsSelected
            ? new SolidColorBrush(0xff3393df)
            : new SolidColorBrush(this.currentRow.Cells[this.cellCounter].BackgroundColor);
        this.cellCounter++;
        if (this.cellCounter >= this.currentRow.Cells.Count)
        {
            this.currentRow = null;
        }

        return brush;
    }

    /// <summary>
    /// Method to convert from SolidColorBrush back to list of RowViewModels.
    /// </summary>
    /// <param name="value">object.</param>
    /// <param name="targetType">Type.</param>
    /// <param name="parameter">object?.</param>
    /// <param name="culture">CultureInfo.</param>
    /// <returns>potentially null object.</returns>
    /// <exception cref="NotImplementedException">It's not needed here.</exception>
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}