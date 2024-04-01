// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using System;
using System.Collections.Generic;
using System.Linq;
using SpreadsheetEngine;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

/// <summary>
/// MainWindowViewModel class. Here is where it takes logic from SpreadsheetEngine and does stuff with it.
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    private const int RowCount = 50;
    private const int ColumnCount = 'Z' - 'A' + 1;

    // CellViewModel related stuff.
    private readonly List<CellViewModel> selectedCells = [];

    // The Spreadsheet itself.
    private Spreadsheet spreadsheet;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class with InitializeSpreadsheet.
    /// </summary>
    public MainWindowViewModel()
    {
        this.SpreadsheetData = [];
        this.InitializeSpreadsheet();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    /// <param name="spreadsheetData">list of list of Cells.</param>
    // ReSharper disable once UnusedMember.Global
    public MainWindowViewModel(List<RowViewModel> spreadsheetData)
    {
        this.SpreadsheetData = spreadsheetData;
    }

    /// <summary>
    /// Gets or sets spreadsheetData.
    /// </summary>
    public List<RowViewModel> SpreadsheetData { get; set; }

    /// <summary>
    /// Gets the Rows Property.
    /// </summary>
    // ReSharper disable once UnassignedGetOnlyAutoProperty - Asked for from Assignment.
    public Cell[][] Rows { get; }

    /// <summary>
    /// The Event handler for the HW Demo Button. For each cell it clears text, if it's column A it sets the Value to
    /// Whatever is in column B of that row, if it's column B it sets the Text and value to Hello World with the
    /// related row int, otherwise it has a random chance of setting that cell's Value to a shrug emoji with a number
    /// indicator to show that it's happened 50 times, upon which that chance will no longer happen.
    /// </summary>
    public void DoDemoHw()
    {
        var totalRandom = 0;
        var random = new Random(); // The random class being started
        for (var row = 0; row < RowCount; row++)
        {
            for (var col = 0; col < ColumnCount; col++)
            {
                this.spreadsheet[row, col].Text = string.Empty; // Clears the cell's Text so we can start fresh here
                switch (col)
                {
                    case 0: // Sets Text to whatever is in Column B of that respective Cell
                        this.spreadsheet[row, col].Text = $"={(char)(col + 'A' + 1)}{row + 1}";
                        break;
                    case 1: // Sets it to Hello World {row header int}
                        this.spreadsheet[row, col].Text = $"Hello from B{row + 1:d2}!";
                        break;
                    default:
                    {
                        // Random chance of setting a cell to the emoji, unless it's been done 50 times now
                        if (random.Next(0, 20) >= 18 && totalRandom < 50)
                        {
                            this.spreadsheet[row, col].Text = $"\u00af\\_(ツ)_/\u00af #{++totalRandom}";
                        }

                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Gets the cell from SpreadsheetData's ViewModels.
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">integer.</param>
    /// <returns>Cell.</returns>
    public Cell GetCell(int row, int col)
    {
        return this.SpreadsheetData[row][col].Cell;
    }

    /// <summary>
    /// Gets the CellViewModel from SpreadsheetData's ViewModels.
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">integer.</param>
    /// <returns>CellViewModel.</returns>
    public CellViewModel GetCellModel(int row, int col)
    {
        return this.SpreadsheetData[row][col];
    }

    /// <summary>
    /// Sets a cell's text.
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">integer.</param>
    /// <param name="value">string.</param>
    public void SetCellText(int row, int col, string value)
    {
        this.SpreadsheetData[row][col].Cell.Text = value;
    }

    public void SelectCell(int rowIndex, int colIndex)
    {
        var clickedCell = this.GetCellModel(rowIndex, colIndex);
        var shouldEditCell = clickedCell.IsSelected;
        this.ResetSelection();

        // Add the pressed cell back to the list
        this.selectedCells.Add(clickedCell);
    }

    public void ResetSelection()
    {
        // Clear currents election
        foreach (var cell in this.selectedCells)
        {
            cell.IsSelected = false;
            cell.CanEdit = false;
        }

        this.selectedCells.Clear();
    }

    public void ToggleCellSelection(int rowIndex, int colIndex)
    {
        var clickedCell = this.GetCellModel(rowIndex, colIndex);
        if (clickedCell.IsSelected == false)
        {
            this.selectedCells.Add(clickedCell);
            clickedCell.IsSelected = true;
        }
        else
        {
            this.selectedCells.Remove(clickedCell);
            clickedCell.IsSelected = false;
        }
    }

    /// <summary>
    /// Gets a cell's text.
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">integer.</param>
    /// <returns>string.</returns>
    public string GetCellText(int row, int col)
    {
        return this.SpreadsheetData[row][col].Cell.Text;
    }

    /// <summary>
    /// Initializes the spreadsheet by making rows of Cell class.
    /// (Temporary fix until then is a List of List of char and string).
    /// </summary>
    private void InitializeSpreadsheet()
    {
        this.SpreadsheetData = [];
        this.spreadsheet = new Spreadsheet(RowCount, ColumnCount);
        foreach (var rowInd in Enumerable.Range(0, RowCount))
        {
            var column = new List<CellViewModel>();
            foreach (var columnInd in Enumerable.Range(0, ColumnCount))
            {
                // var cellTemp = this.spreadsheet.GetCell(rowInd, columnInd);
                // cellTemp.Text = "test";
                var cell = this.spreadsheet.GetCell(rowInd, columnInd);
                column.Add(new CellViewModel(cell));
            }

            var newColumn = new RowViewModel(column);
            this.SpreadsheetData.Add(newColumn);
        }
    }
}