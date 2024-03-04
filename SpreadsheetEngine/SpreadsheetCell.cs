// <copyright file="SpreadsheetCell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1200
using System.ComponentModel;
using System.Runtime.CompilerServices;
#pragma warning restore SA1200

namespace SpreadsheetEngine;

/// <summary>
/// The private SpreadsheetCell class that is the implementation of the Cell class
/// We'll be using this inside the Spreadsheet to make our cells
/// </summary>
internal class SpreadsheetCell(int row, int col) : Cell(row, col)
{
    /// <summary>
    /// PropertyChanging event handler.
    /// </summary>
    public event PropertyChangingEventHandler? PropertyChanging = (sender, e) => { };

    /// <summary>
    /// Sets value with val.
    /// </summary>
    /// <param name="val">string.</param>
    public void SetValue(string val)
    {
        this.value = val;
        this.OnPropertyChanged("Value");
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
    /// Gets or sets overriden Text property. When text changes, before changing it,
    /// it sends an event for one event to stop caring.
    /// </summary>
    public override string Text
    {
        get => base.Text;
        set
        {
            this.OnPropertyChanging();
            base.Text = value;
            this.OnPropertyChanged();
        }
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
    /// Receives notification that Value of another cell has changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OtherOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "Value")
        {
            this.OnPropertyChanged("Text");
        }
    }
}