// <copyright file="CellViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ReactiveUI;
using SpreadsheetEngine;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

/// <summary>
/// CellViewModel class. It's the ViewModel version of Cell class.
/// </summary>
public sealed class CellViewModel : ViewModelBase
{
    private bool canEdit;

    /// <summary>
    ///   Indicates if a cell is selected.
    /// </summary>
    private bool isSelected;

    /// <summary>
    /// Initializes a new instance of the <see cref="CellViewModel"/> class.
    /// </summary>
    /// <param name="cell">Cell.</param>
    public CellViewModel(Cell cell)
    {
        this.Cell = cell;
        this.isSelected = false;
        this.canEdit = false; // Starts off false, needs to be this later

        // We forward the notifications from the cell model to the view model
        // note that we forward using args.PropertyName because Cell and CellViewModel properties have the same
        // names to simplify the procedure. If they had different names, we would have a more complex implementation to
        // do the property names matching
        this.Cell.PropertyChanged += (sender, args) => { this.RaisePropertyChanged(args.PropertyName); };
    }

    /// <summary>
    /// Gets the cell property.
    /// </summary>
    public Cell Cell { get; }

    /// <summary>
    /// Gets or sets a value indicating whether it can set the value or not.
    /// </summary>
    public bool IsSelected
    {
        get => this.isSelected;
        set => this.RaiseAndSetIfChanged(ref this.isSelected, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether it can set the value or not.
    /// </summary>
    public bool CanEdit
    {
        get => this.canEdit;
        set => this.RaiseAndSetIfChanged(ref this.canEdit, value);
    }

    /// <summary>
    /// Gets or sets Text property.
    /// </summary>
    public string? Text
    {
        get => this.Cell.Text;
        set
        {
            if (value != null)
            {
                this.Cell.Text = value;
            }
        }
    }

    /// <summary>
    /// Gets Value property.
    /// </summary>
    public string Value => this.Cell.Value;

    /// <summary>
    /// Gets or sets BackgroundColor property.
    /// </summary>
    public uint BackgroundColor
    {
        get => this.Cell.BgColor;
        set => this.Cell.BgColor = value;
    }
}