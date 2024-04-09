// <copyright file="CommandFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;
using Spreadsheet_Bruno_SanchezParra.ViewModels;
using SpreadsheetEngine.Exceptions;

namespace Spreadsheet_Bruno_SanchezParra.Commands;

/// <summary>
/// The Factory class for Commands. All commands that are created will go to a Controller class.
/// </summary>
public class CommandFactory
{
    /// <summary>
    /// Factory method that makes commands about a cell and a new given value based on the fieldName parameter.
    /// </summary>
    /// <param name="cell">CellViewModel.</param>
    /// <param name="fieldName">string.</param>
    /// <param name="newValue">object.</param>
    /// <returns>Command that uses IUndoRedoCommand.</returns>
    /// <exception cref="InvalidFieldNameException">Field name is not accepted.</exception>
    /// <exception cref="InvalidFieldType">The type of the new value is not the same as the old type.</exception>
    public static IUndoRedoCommand CreateCommand(CellViewModel cell, string fieldName, object newValue)
    {
        var property = cell.GetType().GetProperty(
            fieldName,
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
        if (property == null)
        {
            throw new InvalidFieldNameException(fieldName);
        }

        if (property.GetType() == newValue.GetType())
        {
            throw new InvalidFieldType(newValue.GetType().ToString());
        }

        return fieldName switch
        {
            nameof(CellViewModel.Text) => new TextChangeCommand(cell, (string)newValue),
            nameof(CellViewModel.BackgroundColor) => new ColorChangeCommand(cell, (uint)newValue),
            _ => throw new InvalidFieldNameException(fieldName)
        };
    }
}