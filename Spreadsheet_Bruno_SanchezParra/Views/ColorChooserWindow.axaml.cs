// <copyright file="ColorChooserWindow.axaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra.Views;

public partial class ColorChooserWindow : ReactiveWindow<ColorChooserViewModel>
{
    public ColorChooserWindow()
    {
        this.InitializeComponent();
        this.WhenActivated(action => action(this.ViewModel!.OKButtonCommand.Subscribe(this.Close)));
        this.WhenActivated(action => action(this.ViewModel!.CancelButtonCommand.Subscribe(this.Close)));

    }
}