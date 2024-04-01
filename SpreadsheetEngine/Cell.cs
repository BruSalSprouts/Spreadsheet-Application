// <copyright file="Cell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SpreadsheetEngine;

/// <summary>
/// The Cell class. Contains all methods, fields, and properties related to the Cell itself.
/// </summary>
public abstract class Cell : INotifyPropertyChanged
{
#pragma warning disable SA1600
    // ReSharper disable once InconsistentNaming
    private string text;

    private uint bgColor;

    // ReSharper disable once InconsistentNaming
    protected string value;
#pragma warning restore SA1600

    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class.
    /// </summary>
    protected Cell()
    {
        this.text = string.Empty;
        this.value = string.Empty;
        this.bgColor = 0xFFFFFFFF;
    }

    /// <summary>
    /// Gets or sets makes BGColor property.
    /// </summary>
    public uint BgColor
    {
        get => this.bgColor;
        set
        {
            // Conditional to ignore if new value is same as old value
            if (this.BgColor == value)
            {
                return;
            }

            this.bgColor = value;

            // Event handler for if text changes
            // this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Text)));
            this.OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets makes Text property.
    /// </summary>
    public virtual string Text
    {
        get => this.text; // Getter
        set // Setter
        {
            // Conditional to ignore if new value is same as old value
            if (string.Equals(this.text, value, StringComparison.Ordinal))
            {
                return;
            }

            this.text = value;

            // Event handler for if text changes
            // this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Text)));
            this.OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets publicly gets or Protected sets to make the Value property.
    /// </summary>
    public virtual string Value => this.value;

    /// <summary>
    /// Event handler method for PropertyChanged event. Sends message to subscribers of PropertyChanged handler.
    /// </summary>
    /// <param name="propertyName">[CallerMemberName] string?.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}