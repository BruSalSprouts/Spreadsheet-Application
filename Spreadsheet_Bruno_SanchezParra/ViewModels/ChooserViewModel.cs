// <copyright file="ChooserViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;
using Avalonia.Media;
using ReactiveUI;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

public class ChooserViewModel : ViewModelBase
{
    private Color colour;

    public ChooserViewModel(Color color)
    {
        this.colour = color;
    }

    public Color Colour
    {
        get => this.colour;
        set => this.colour = value;
    }
}