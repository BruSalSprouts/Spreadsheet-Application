// <copyright file="Text.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Spreadsheet_Bruno_Sanchez.Models;

public class Cell
{
    public string Text { get; set; }

    public Cell(string data)
    {
        Text = data;
    }
}