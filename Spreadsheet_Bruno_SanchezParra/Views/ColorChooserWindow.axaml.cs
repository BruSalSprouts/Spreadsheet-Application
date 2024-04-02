// <copyright file="ColorChooserWindow.axaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra.Views;

/// <summary>
/// ColorChooserWindow class.
/// </summary>
public partial class ColorChooserWindow : ReactiveWindow<ColorChooserViewModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ColorChooserWindow"/> class.
    /// </summary>
    public ColorChooserWindow()
    {
        this.InitializeComponent();
        this.WhenActivated(action => action(this.ViewModel!.OkButtonCommand.Subscribe(this.Close)));
        this.WhenActivated(action => action(this.ViewModel!.CancelButtonCommand.Subscribe(this.Close)));
    }
}