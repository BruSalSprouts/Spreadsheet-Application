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
    protected string value;

    // ReSharper disable once InconsistentNaming
    private string text;

    private uint bgColor;
    private uint textColor;
    private bool dirty;

#pragma warning restore SA1600

    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class.
    /// </summary>
    protected Cell()
    {
        this.dirty = false;
        this.text = string.Empty;
        this.value = string.Empty;
        this.bgColor = 0xFFFFFFFF;
        this.textColor = 0xFF000000;
    }

    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

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
            this.dirty = true;

            // Event handler for if text changes
            this.OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets or sets TextColor property.
    /// </summary>
    public uint TextColor
    {
        get => this.textColor;
        set
        {
            // Conditonal to ignore if new value is same as old value
            if (this.textColor == value)
            {
                return;
            }

            this.textColor = value;
            this.dirty = true;

            // Event handler for if text changes
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
            this.dirty = true;

            // Event handler for if text changes
            this.OnPropertyChanged();
        }
    }

    /// <summary>
    /// Gets publicly gets or Protected sets to make the Value property.
    /// </summary>
    public virtual string Value => this.value;

    /// <summary>
    /// Gets or sets a value indicating whether it gets or sets dirty property.
    /// </summary>
    public bool Dirty
    {
        get => this.dirty;
        set => this.dirty = value;
    }

    /// <summary>
    /// Event handler method for PropertyChanged event. Sends message to subscribers of PropertyChanged handler.
    /// </summary>
    /// <param name="propertyName">[CallerMemberName] string?.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}