// <copyright file="RowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.ComponentModel;
using ReactiveUI;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

/// <summary>
/// RowViewModel class.
/// </summary>
public class RowViewModel : ViewModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RowViewModel"/> class.
    /// </summary>
    /// <param name="cells">List of CellViewModels.</param>
    public RowViewModel(List<CellViewModel> cells)
    {
        this.Cells = cells;
        foreach (var cell in this.Cells)
        {
            cell.PropertyChanged += this.CellOnPropertyChanged;
        }

        this.SelfReference = this;
    }

    /// <summary>
    /// Gets or sets Cells property.
    /// </summary>
    public List<CellViewModel> Cells { get; set; }

    /// <summary>
    /// Gets the SelfReference property.
    /// </summary>
    public RowViewModel SelfReference { get; private set; }

    /// <summary>
    /// Indexer for the Cell in the RowViewModel.
    /// </summary>
    /// <param name="index">int.</param>
    public CellViewModel this[int index] => this.Cells[index];

    /// <summary>
    /// Event handler to show CellViewModel changes.
    /// </summary>
    private void FireChangedEvent()
    {
        this.RaisePropertyChanged(nameof(this.SelfReference));
    }

    /// <summary>
    /// PropertyChangedEventArgs Event handler.
    /// </summary>
    /// <param name="sender">object.</param>
    /// <param name="args">PropertyChangedEventArgs.</param>
    private void CellOnPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            var styleImpactingProperties = new List<string>
            {
                nameof(CellViewModel.IsSelected),
                nameof(CellViewModel.CanEdit),
                nameof(CellViewModel.BackgroundColor),
            };
            if (args.PropertyName != null && styleImpactingProperties.Contains(args.PropertyName))
            {
                this.FireChangedEvent();
            }
        }
}