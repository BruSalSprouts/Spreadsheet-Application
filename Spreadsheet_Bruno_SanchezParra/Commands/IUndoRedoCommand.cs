// <copyright file="IUndoRedoCommands.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Spreadsheet_Bruno_SanchezParra.Commands;

/// <summary>
/// Base interface for Commands relating to undo and redo.
/// </summary>
public interface IUndoRedoCommand
{
    /// <summary>
    /// Executes a command.
    /// </summary>
    public void Execute();

    /// <summary>
    /// Undo a previously executed command.
    /// </summary>
    public void Undo();
}