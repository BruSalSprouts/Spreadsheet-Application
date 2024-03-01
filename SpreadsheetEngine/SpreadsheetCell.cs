// <copyright file="SpreadsheetCell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SpreadsheetEngine;

/// <summary>
/// The private SpreadsheetCell class that is the implementation of the Cell class
/// We'll be using this inside the Spreadsheet to make our cells
/// </summary>
internal class SpreadsheetCell(int row, int col) : Cell(row, col), INotifyPropertyChanged
{
    // The Event Handler for SpreadsheetCell, PropertyChanging
    public event PropertyChangingEventHandler? PropertyChanging = (sender, e) => { };

    /// <summary>
    /// Sets value with val
    /// </summary>
    /// <param name="val"></param>
    public void SetValue(string val)
    {
        this.value = val;
        this.OnPropertyChanged("Value");
    }

    /// <summary>
    /// Binds Spreadsheet Cell Value change from another cell (Calls event to do so)
    /// </summary>
    /// <param name="other"></param>
    public void Bind(Cell other)
    {
        other.PropertyChanged += OtherOnPropertyChanged;
    }

    /// <summary>
    /// Unbinds Spreadsheet Cell Value change from another cell (Calls event to remove this)
    /// </summary>
    /// <param name="other"></param>
    public void Unbind(Cell other)
    {
        other.PropertyChanged -= OtherOnPropertyChanged;
    }

    /// <summary>
    /// Gets or sets overriden Text property. When text changes, before changing it,
    /// it sends an event for one event to stop caring
    /// </summary>
    public override string Text
    {
        get => base.Text;
        set
        {
            this.OnPropertyChanging();
            base.Text = value;
        }
    }

    /// <summary>
    /// Receives notification that Text is about to change
    /// </summary>
    /// <param name="propertyName"></param>
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