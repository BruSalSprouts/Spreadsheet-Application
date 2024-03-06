// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
#pragma warning disable SA1200
using System.ComponentModel;
#pragma warning restore SA1200

namespace SpreadsheetEngine;

/// <summary>
/// The Spreadsheet class. Handles stuff at the spreadsheet level.
/// </summary>
public class Spreadsheet
{
    // Reasoning: Fields will be used later
#pragma warning disable CS0169 // Field is never used
    private int rows; // int value for RowCount
    private int columns; // int value for ColumnCount
#pragma warning restore CS0169 // Field is never used

    private List<List<SpreadsheetCell>> cells = null!;

    // The Event Handler for Spreadsheet, CellPropertyChanged

    /// <inheritdoc cref="CellPropertyChanged" />
    public event PropertyChangedEventHandler? CellPropertyChanged = (sender, e) => { };

    /// <summary>
    /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
    /// Also checks for invalid row and column numbers.
    /// </summary>
    /// <param name="rowNum">ìnt.</param>
    /// <param name="colNum">Int. </param>
    /// <exception cref="ArgumentOutOfRangeException">Error handling.</exception>
    public Spreadsheet(int rowNum, int colNum)
    {
        // The following Exceptions will prevent the Spreadsheet from having invalid rows and columns
        ArgumentOutOfRangeException.ThrowIfLessThan(rowNum, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(colNum, 1);

        this.Rows = rowNum;
        this.Columns = colNum;
        this.InitializeCells(rowNum, colNum);
    }

    /// <summary>
    /// Gets or sets property for Rows.
    /// </summary>
    public int Rows { get; set; }

    /// <summary>
    /// Gets or sets property for Columns.
    /// </summary>
    public int Columns { get; set; }

    /// <summary>
    /// Gets a Cell from the 2D List at location cells[row, col].
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">Int.</param>s
    public Cell this[int row, int col] => this.GetCell(row, col);

    /// <summary>
    ///  Takes rowInd and colInd and returns the cell at that location or null if there is no such cell.
    /// </summary>
    /// <param name="rowInd">int.</param>
    /// <param name="colInd">integer.</param>
    /// <returns>an Cell object.</returns>
    public Cell GetCell(int rowInd, int colInd)
    {
        if (rowInd < 0 || rowInd >= this.Rows || colInd < 0 || colInd >= this.Columns)
        {
            // Out of bounds exception check
            throw new IndexOutOfRangeException("The rows and columns have to be within range!");
        }

        return this.cells[rowInd][colInd];
    }

    /// <summary>
    /// Returns the number of columns in the spreadsheet.
    /// </summary>
    /// <returns>int columns.</returns>
    public int ColumnCount()
    {
        return this.Columns;
    }

    /// <summary>
    /// Returns the number of rows in the spreadsheet.
    /// </summary>
    /// <returns>int rows.</returns>
    public int RowCount()
    {
        return this.Rows;
    }

    /// <summary>
    /// Updates the Value of the respective cell[rowInd][colInd]. If the Text of the cell doesn't
    /// start with '=', then the value is just set to the text. Otherwise the value must be
    /// gotten from the value of the cell whose name follows the '='.
    /// </summary>
    /// <param name="sender">SpreadsheetCell.</param>
    private void ValueUpdate(SpreadsheetCell sender)
    {
        var tempText = sender.Text;
        var nextValue = tempText;
        if (nextValue != sender.Value)
        {
            if (!string.IsNullOrEmpty(tempText) && tempText[0] == '=')
            {
                // The following part is just getting the right Cell name
                string cellText = tempText[1..].ToUpper();
                int colInd = cellText[0] - 'A';
                int rowInd = int.Parse(cellText[1..]) - 1;

                // gets the cell after having the name
                var otherCell = this.GetCell(rowInd, colInd);
                nextValue = otherCell.Value;

                // Calls the Bind function from SpreadsheetCell
                sender.Bind(otherCell);
            }

            sender.SetValue(nextValue);
        }
    }

    /// <summary>
    /// Initializes the 2D list of cells by initializing each cell within the 2D list.
    /// </summary>
    /// <param name="rowNum">int row index.</param>
    /// <param name="colNum">int col index.</param>
    private void InitializeCells(int rowNum, int colNum)
    {
        this.cells = [];
        for (var r = 0; r < rowNum; r++)
        {
            // Each column from here will have it's cells affected
            List<SpreadsheetCell> column = [];
            for (var c = 0; c < colNum; c++)
            {
                var cell = new SpreadsheetCell(r, c);

                column.Add(cell);

                // Time to announce the event of the new cell creation
                cell.PropertyChanged += this.NotifyPropertyChanged;
                cell.PropertyChanging += this.OnPropertyChanging;
            }

            this.cells.Add(column);
        }
    }

    /// <summary>
    /// Removes notification from other cell.
    /// </summary>
    /// <param name="cell">SpreadsheetCell.</param>
    private void Unbind(SpreadsheetCell cell)
    {
        var tempText = cell.Text;
        if (tempText.Length > 2 && tempText[0] == '=')
        {
            // Makes sure the right cell's name is being called so that cell is no longer bound
            var cellText = tempText[1..].ToUpper();
            var colInd = cellText[0] - 'A';
            var rowInd = int.Parse(cellText[1..]) - 1;
            var otherCell = this.GetCell(rowInd, colInd);

            // Calls the Unbind method from SpreadsheetCell class
            cell.Unbind(otherCell);
        }
    }

    /// <summary>
    /// Where CellPropertyCHanged is being handled, and also updates the cell's Value.
    /// </summary>
    /// <param name="sender">object.</param>
    /// <param name="e">PropertyChangedEventArgs.</param>
    private void NotifyPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is SpreadsheetCell cell && e.PropertyName == "Text")
        {
            this.ValueUpdate(cell);
        }

        this.CellPropertyChanged?.Invoke(sender, e);
    }

    /// <summary>
    /// Receives notification that Text is about to change.
    /// </summary>
    /// <param name="sender">object.</param>
    /// <param name="e">PropertyChangedEventArgs.</param>
    private void OnPropertyChanging(object? sender, PropertyChangingEventArgs e)
    {
        if (sender is SpreadsheetCell cell && e.PropertyName == "Text")
        {
            this.Unbind(cell);
        }
    }
}