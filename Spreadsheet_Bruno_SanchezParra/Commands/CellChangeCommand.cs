// <copyright file="CellChangeCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Spreadsheet_Bruno_SanchezParra.ViewModels;
using SpreadsheetEngine;

namespace Spreadsheet_Bruno_SanchezParra.Commands;

/// <summary>
/// Base class for Cell changing related commands.
/// </summary>
public abstract class CellChangeCommand : IUndoRedoCommand
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CellChangeCommand"/> class.
    /// </summary>
    /// <param name="cell">Cell.</param>
    internal CellChangeCommand(CellViewModel cell)
    {
        this.Cell = cell;
    }

    protected CellViewModel Cell
    {
        get;
        set;
    }

    /// <inheritdoc/>
    public abstract void Execute();

    /// <inheritdoc/>
    public abstract void Undo();
}