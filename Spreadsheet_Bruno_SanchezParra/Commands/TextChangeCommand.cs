// <copyright file="TextChangeCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra.Commands;

/// <summary>
/// Base class for Text-changing-related commands.
/// </summary>
public class TextChangeCommand : CellChangeCommand
{
    private string? oldText;
    private string newText;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextChangeCommand"/> class.
    /// </summary>
    /// <param name="cell">Cell.</param>
    /// <param name="newText">string.</param>
    public TextChangeCommand(CellViewModel cell, string newText)
        : base(cell)
    {
        this.oldText = cell.Text;
        this.newText = newText;
    }

    /// <inheritdoc/>
    public override void Execute()
    {
        this.oldText = this.Cell.Text;
        this.Cell.Text = this.newText;
    }

    /// <inheritdoc/>
    public override void Undo()
    {
        this.Cell.Text = this.oldText;
    }

    /// <summary>
    /// Returns a string that contains the old Text contents and the new Text contents.
    /// </summary>
    /// <returns>string.</returns>
    public override string ToString()
    {
        return $"{this.oldText} >= {this.newText}";
    }
}