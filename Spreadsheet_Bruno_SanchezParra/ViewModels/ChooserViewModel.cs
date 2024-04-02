// <copyright file="ChooserViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Avalonia.Media;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

/// <summary>
/// ChooserViewModel class.
/// </summary>
public class ChooserViewModel : ViewModelBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChooserViewModel"/> class.
    /// </summary>
    /// <param name="color">Color.</param>
    public ChooserViewModel(Color color)
    {
        this.Colour = color;
    }

    /// <summary>
    /// Gets or sets Colour property.
    /// </summary>
    public Color Colour { get; set; }
}