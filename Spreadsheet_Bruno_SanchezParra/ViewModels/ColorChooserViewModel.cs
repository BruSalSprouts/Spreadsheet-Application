// <copyright file="ColorChooserViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

public class ColorChooserViewModel : ViewModelBase
{
    private Color color;
    private string? dummyText;
    private ChooserViewModel? selectedColor;

    
    public ColorChooserViewModel(Color color)
    {
        this.color = color;
        this.OKButtonCommand = ReactiveCommand.Create(
            () => this.SelectedColor);
        this.CancelButtonCommand = ReactiveCommand.Create(
            () =>
            {
                this.selectedColor = null;
                return this.SelectedColor;
            });
        this.SelectedColor = new ChooserViewModel(this.color);
    }

    public ReactiveCommand<Unit, ChooserViewModel?> OKButtonCommand { get; }

    public ReactiveCommand<Unit, ChooserViewModel?> CancelButtonCommand { get; }

    public Color Color
    {
        get => this.color;
        set
        {
            this.RaiseAndSetIfChanged(ref this.color, value);
            Console.WriteLine(value);
            var chooserViewModel = this.selectedColor;
            if (chooserViewModel != null)
            {
                chooserViewModel.Colour = value;
            }
        }
    }

    public string? DummyText
    {
        get => this.dummyText;
        set => this.RaiseAndSetIfChanged(ref this.dummyText, value);
    }

    private ChooserViewModel? SelectedColor
    {
        get => this.selectedColor;
        set => this.RaiseAndSetIfChanged(ref this.selectedColor, value);
    }
}