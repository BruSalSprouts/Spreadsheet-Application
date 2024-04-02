// <copyright file="ColorChooserViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Reactive;
using Avalonia.Media;
using ReactiveUI;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

/// <summary>
/// ColorChooserViewModel class.
/// </summary>
public class ColorChooserViewModel : ViewModelBase
{
    private Color color;
    private ChooserViewModel? selectedColor;

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorChooserViewModel"/> class.
    /// </summary>
    /// <param name="color">Color.</param>
    public ColorChooserViewModel(Color color)
    {
        this.color = color;
        this.OkButtonCommand = ReactiveCommand.Create(
            () => this.SelectedColor);
        this.CancelButtonCommand = ReactiveCommand.Create(
            () =>
            {
                this.selectedColor = null;
                return this.SelectedColor;
            });
        this.SelectedColor = new ChooserViewModel(this.color);
    }

    /// <summary>
    /// Gets OKButtonCommand property.
    /// </summary>
    public ReactiveCommand<Unit, ChooserViewModel?> OkButtonCommand { get; }

    /// <summary>
    /// Gets CancelButtonCommand property.
    /// </summary>
    public ReactiveCommand<Unit, ChooserViewModel?> CancelButtonCommand { get; }

    /// <summary>
    /// Gets or sets Color property. Setter checks to see if there's selected values before setting their colors too.
    /// </summary>
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

    /// <summary>
    /// Gets or sets SelectedColor property.
    /// </summary>
    private ChooserViewModel? SelectedColor
    {
        get => this.selectedColor;
        set => this.RaiseAndSetIfChanged(ref this.selectedColor, value);
    }
}