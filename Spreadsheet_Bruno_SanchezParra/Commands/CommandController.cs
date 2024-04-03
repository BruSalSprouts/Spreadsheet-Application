// <copyright file="Controller.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using ReactiveUI;
using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra.Commands;

public class CommandController
{
    private static CommandController? instance = null;
    private readonly Stack<IUndoRedoCommand> undoStack;
    private readonly Stack<IUndoRedoCommand> redoStack;

    private CommandController()
    {
        this.undoStack = new Stack<IUndoRedoCommand>();
        this.redoStack = new Stack<IUndoRedoCommand>();
    }

    private void Push(IUndoRedoCommand command)
    {
        Console.WriteLine(command);
        this.undoStack.Push(command);
    }
    
    public static CommandController GetInstance()
    {
        return instance ??= new CommandController();
    }
    
    public void InvokeTextChange(CellViewModel cell, string newText)
    {
        var command = new TextChangeCommand(cell, newText);
        command.Execute();
        this.Push(command);
    }
    
    public void InvokeColorChange(CellViewModel cell, uint newColorCode)
    {
        var command = new ColorChangeCommand(cell, newColorCode);
        command.Execute();
        this.Push(command);
    }

    public void Undo()
    {
        if (this.undoStack.Count > 0)
        {
            var command = this.undoStack.Pop();
            command.Undo();
            this.redoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (this.redoStack.Count > 0)
        {
            var command = this.redoStack.Pop();
            command.Execute();
            this.undoStack.Push(command);
        }
    }

    public bool UndoStackEnabled()
    {
        return this.undoStack.Count > 0;
    }

    public bool RedoStackEnabled()
    {
        return this.redoStack.Count > 0;
    }
}