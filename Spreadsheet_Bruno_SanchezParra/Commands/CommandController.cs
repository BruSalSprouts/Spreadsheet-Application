// <copyright file="CommandController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra.Commands;

/// <summary>
/// Controller class. Here is where the commands are executed.
/// </summary>
public class CommandController
{
    private static CommandController? instance;
    private readonly Stack<IUndoRedoCommand> undoStack;
    private readonly Stack<IUndoRedoCommand> redoStack;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandController"/> class.
    /// </summary>
    private CommandController()
    {
        this.undoStack = new Stack<IUndoRedoCommand>();
        this.redoStack = new Stack<IUndoRedoCommand>();
    }

    /// <summary>
    /// Gets an instance of the CommandController class, if that instance doesn't exist, it'll then be created.
    /// </summary>
    /// <returns>CommandController.</returns>
    public static CommandController GetInstance()
    {
        return instance ??= new CommandController();

        // This is a singleton pattern!
    }

    /// <summary>
    /// Invokes a change to property by setting that property to newValue.
    /// It also clears the redo stack.
    /// </summary>
    /// <param name="cell">CellViewModel.</param>
    /// <param name="property">string.</param>
    /// <param name="newValue">object.</param>
    public void InvokeChange(CellViewModel cell, string property, object newValue)
    {
        var command = CommandFactory.CreateCommand(cell, property, newValue);
        command.Execute();
        this.Push(command);
        this.redoStack.Clear();
    }

    /// <summary>
    /// Undoes a command that was executed and pushes it to the redo stack.
    /// </summary>
    public void Undo()
    {
        if (this.undoStack.Count > 0)
        {
            var command = this.undoStack.Pop();
            command.Undo();
            this.redoStack.Push(command);
        }
    }

    /// <summary>
    /// Redoes a command that was undone and pushes it to the undo stack.
    /// </summary>
    public void Redo()
    {
        if (this.redoStack.Count > 0)
        {
            var command = this.redoStack.Pop();
            command.Execute();
            this.undoStack.Push(command);
        }
    }

    /// <summary>
    /// Returns whether there's something in the undo stack.
    /// </summary>
    /// <returns>boolean.</returns>
    public bool UndoStackEnabled()
    {
        return this.undoStack.Count > 0;
    }

    /// <summary>
    /// Returns whether there's something in the redo stack.
    /// </summary>
    /// <returns>boolean.</returns>
    public bool RedoStackEnabled()
    {
        return this.redoStack.Count > 0;
    }

    /// <summary>
    /// Clears the redo and undo stacks.
    /// </summary>
    public void ClearStacks()
    {
        this.undoStack.Clear();
        this.redoStack.Clear();
    }

    /// <summary>
    /// Pushes a command to the undoStack Stack.
    /// </summary>
    /// <param name="command">Instance of IUndoRedoCommand.</param>
    private void Push(IUndoRedoCommand command)
    {
        Console.WriteLine(command);
        this.undoStack.Push(command);
    }
}