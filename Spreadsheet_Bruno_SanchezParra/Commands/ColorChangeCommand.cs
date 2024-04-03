// <copyright file="ColorChangeCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Spreadsheet_Bruno_SanchezParra.ViewModels;
using SpreadsheetEngine;

namespace Spreadsheet_Bruno_SanchezParra.Commands;

/// <summary>
/// Base class for Background-color-changing-related commands.
/// </summary>
public class ColorChangeCommand : CellChangeCommand
{
    private uint oldColor;
    private uint newColor;

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorChangeCommand"/> class.
    /// </summary>
    /// <param name="cell">Cell.</param>
    /// <param name="newColor">uint.</param>
    public ColorChangeCommand(CellViewModel cell, uint newColor)
        : base(cell)
    {
        this.newColor = newColor;
    }

    /// <inheritdoc/>
    public override void Execute()
    {
        this.oldColor = this.Cell.BackgroundColor;
        this.Cell.BackgroundColor = this.newColor;
    }

    /// <inheritdoc/>
    public override void Undo()
    {
        this.Cell.BackgroundColor = this.oldColor;
    }
}