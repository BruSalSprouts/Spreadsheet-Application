﻿using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using SpreadsheetEngine;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    // So since we don't yet have the Spreadsheet or Cell classes done, we'll just make the spreadsheets 
    // using lists for now
    public List<List<Cell>> SpreadsheetData { get; set; }

    private Spreadsheet spreadsheet;
    private const int RowCount = 50;
    private const int ColumnCount = 'Z' - 'A' + 1;
    public Cell[][] Rows { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class with InitializeSpreadsheet.
    /// </summary>
    public MainWindowViewModel()
    {
        this.SpreadsheetData = [];
        this.InitializeSpreadsheet();
    }

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
    /// Initializes the spreadsheet by making rows of Cell class.
    /// (Temporary fix until then is a List of List of char and string)
    /// </summary>
    private void InitializeSpreadsheet()
    {
        this.SpreadsheetData = [];
        this.spreadsheet = new Spreadsheet(RowCount, ColumnCount);
        foreach (var rowInd in Enumerable.Range(0, RowCount))
        {
            var columns = new List<Cell>(ColumnCount);
            foreach (var columnInd in Enumerable.Range(0, ColumnCount))
            {
                // var cellTemp = this.spreadsheet.GetCell(rowInd, columnInd);
                // cellTemp.Text = "test";
                columns.Add(this.spreadsheet.GetCell(rowInd, columnInd));
            }

            this.SpreadsheetData.Add(columns);
        }
    }
}