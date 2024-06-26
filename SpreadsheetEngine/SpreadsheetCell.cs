// <copyright file="SpreadsheetCell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
#pragma warning disable SA1200
using System.ComponentModel;
using System.Runtime.CompilerServices;

#pragma warning disable CS9113 // Parameter is unread.
#pragma warning restore SA1200

namespace SpreadsheetEngine;

/// <summary>
/// The private SpreadsheetCell class that is the implementation of the Cell class
/// We'll be using this inside the Spreadsheet to make our cells.
/// </summary>
internal class SpreadsheetCell(int row, int col) : Cell
{
    /// <summary>
    /// PropertyChanging event handler.
    /// </summary>
    public event PropertyChangingEventHandler? PropertyChanging = (sender, e) => { };

    /// <summary>
    /// Gets row property.
    /// </summary>
    public int Row { get; } = row;

    /// <summary>
    /// Gets col property.
    /// </summary>
    public int Col { get; } = col;

    /// <summary>
    /// Gets row property.
    /// Converts row from int to char by adding 'A' to it.
    /// </summary>
    public string Name { get; } = $"{(char)(col + 'A')}{row + 1}";

    /// <summary>
    /// Gets or sets overriden Text property. When text changes, before changing it,
    /// it sends an event for one event to stop caring.
    /// </summary>
    public override string Text
    {
        get => base.Text;
        set
        {
            if (string.Equals(this.Text, value, StringComparison.Ordinal))
            {
                return;
            }

            this.OnPropertyChanging(); // Triggers the Unbind
            base.Text = value;
        }
    }

    /// <summary>
    /// Sets value with val.
    /// </summary>
    /// <param name="val">string.</param>
    public void SetValue(string val)
    {
        if (string.Equals(this.value, val, StringComparison.Ordinal))
        {
            return;
        }

        this.value = val;
        this.OnPropertyChanged(nameof(this.Value));
    }

    /// <summary>
    /// Override ToString.
    /// </summary>
    /// <returns>string.</returns>
    public override string ToString()
    {
        return this.Name;
    }

    /// <summary>
    /// Binds Spreadsheet Cell Value change from another cell (Calls event to do so).
    /// </summary>
    /// <param name="other">Cell.</param>
    public void Bind(Cell other)
    {
        other.PropertyChanged += this.OtherOnPropertyChanged;
    }

    /// <summary>
    /// Unbinds Spreadsheet Cell Value change from another cell (Calls event to remove this).
    /// </summary>
    /// <param name="other">Cell.</param>
    public void Unbind(Cell other)
    {
        other.PropertyChanged -= this.OtherOnPropertyChanged;
    }

    /// <summary>
    /// Receives notification that Text is about to change.
    /// </summary>
    /// <param name="propertyName">[CallerMemberName] string.</param>
    private void OnPropertyChanging([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
    }

    /// <summary>
    /// Receives notification that Value of another cell has changed.
    /// </summary>
    /// <param name="sender">object.</param>
    /// <param name="e">PropertyChangedEventArgs.</param>
    private void OtherOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != "Value")
        {
            return;
        }

        Console.WriteLine($"OtherOnPropertyChanged || {sender}");
        this.OnPropertyChanged(nameof(this.Text));
    }
}