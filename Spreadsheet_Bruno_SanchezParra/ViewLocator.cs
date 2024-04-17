// <copyright file="ViewLocator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra;

/// <summary>
/// Finds the Views.
/// </summary>
public class ViewLocator : IDataTemplate
{
    /// <summary>
    /// Controller when building View.
    /// </summary>
    /// <param name="data">object.</param>
    /// <returns>Control.</returns>
    public Control? Build(object? data)
    {
        if (data is null)
        {
            return null;
        }

        var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type != null)
        {
            var control = (Control)Activator.CreateInstance(type)!;
            control.DataContext = data;
            return control;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    /// <summary>
    /// Returns whether an object is ViewModelBase.
    /// </summary>
    /// <param name="data">object.</param>
    /// <returns>bool.</returns>
    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}