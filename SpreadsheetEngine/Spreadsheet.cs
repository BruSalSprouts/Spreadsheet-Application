// <copyright file="Spreadsheet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using SpreadsheetEngine;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// Will add private Spreadsheet cell class
namespace SpreadsheetEngine;

public class Spreadsheet
{
    public new event PropertyChangedEventHandler? CellPropertyChanged = (sender, e) => { };

    private int rows;
    private int columns;
    private SpreadsheetCell[,] cells;

    /// <summary>
    /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
    /// Also checks for invalid row and column numbers.
    /// </summary>
    /// <param name="rowNum"></param>
    /// <param name="colNum"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Spreadsheet(int rowNum, int colNum) 
    {
        if (rowNum < 1)
        { // Row error check
            throw new ArgumentOutOfRangeException("rowNum should be positive!");
        }

        if (colNum < 1) 
        { // Column error Check
            throw new ArgumentOutOfRangeException("colNum should be positive!");
        }

        this.Columns = colNum;
        this.Rows = rowNum;
        this.InitializeCells(rowNum, colNum);
    }

    /// <summary>
    /// Initializes the 2D array cells by initializing each cell within the 2D array
    /// </summary>
    /// <param name="rowNum"></param>
    /// <param name="colNum"></param>
    private void InitializeCells(int rowNum, int colNum)
    {
        this.cells = new SpreadsheetCell[rowNum, colNum];
        for (int r = 0; r < rowNum; r++)
        {
            for (int c = 0; c < colNum; c++)
            {
                this.cells[r, c] = new SpreadsheetCell(r, c);
                // Time to announce the event of the new cell creation 
                this.cells[r, c].PropertyChanged += this.NotifyPropertyChanged;
            }
        }
    }
    
    /// <summary>
    /// Property for Rows .
    /// </summary>
    public int Rows { get; set; }

    /// <summary>
    /// Property for Columns.
    /// </summary>
    public int Columns { get; set; }

    /// <summary>
    ///  Takes rowInd and colInd and returns the cell at that location or null if there is no such cell
    /// </summary>
    /// <param name="rowInd" />
    /// <param name="colInd" />
    /// <returns>an Cell object</returns>
    public Cell GetCell(int rowInd, int colInd)
    {
        if (rowInd < 0 || rowInd >= this.Rows || colInd < 0 || colInd >= this.Columns)
        { // Out of bounds exception check
            throw new IndexOutOfRangeException("The rows and columns have to be within range!");
        }

        if (this.cells[rowInd, colInd].Text == string.Empty)
        {
            return null;
        }

        return this.cells[rowInd, colInd];
    }

    /// <summary>
    /// Returns the number of columns in the spreadsheet
    /// </summary>
    /// <returns>int columns</returns>
    public int ColumnCount()
    {
        return this.Columns;
    }

    /// <summary>
    /// Returns the number of rows in the spreadsheet
    /// </summary>
    /// <returns>int rows</returns>
    public int RowCount()
    {
        return this.Rows;
    }

    
    /// <summary>
    /// Updates the Value of the respective cell[rowInd][colInd]. If the Text of the cell doesn't
    /// start with '=', then the value is just set to the text. Otherwise the value must be
    /// gotten from the value of the cell whose name follows the '='
    /// </summary>
    /// <param name="rowInd"></param>
    /// <param name="colInd"></param>
    private void ValueUpdate(SpreadsheetCell sender)
    {
        string tempText = sender.Text;
        if (tempText != string.Empty)
        {
            if (tempText[0] == '=')
            {
                sender.SetValue(this.ValueFromCell(tempText.Substring(1).ToUpper()));
            }
            else
            {
                sender.SetValue(tempText);
            }
        }
    }
    
    /// <summary>
    /// Takes a string, which contains the address for a Cell's location, and returns
    /// the Value of that Cell.
    /// </summary>
    /// <param name="cellText"></param>
    /// <returns> string Value (which comes from a Cell)</returns>
    private string ValueFromCell(string cellText)
    {
        int colInd = cellText[0] - 'A';
        int rowInd = int.Parse(cellText.Substring(1)) - 1;
        return this.GetCell(rowInd, colInd).Value;
    }
    /// <summary>
    /// Where CellPropertyCHanged is being handled, and also updates the cell's Value 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        this.CellPropertyChanged?.Invoke(sender, e);
        ValueUpdate((SpreadsheetCell) sender);
    }

    // private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    // {
    //     this.CellPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    // }

    // protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    // {
    //     if (EqualityComparer<T>.Default.Equals(field, value))
    //     {
    //         return false;
    //     }
    //
    //     field = value;
    //     this.OnPropertyChanged(propertyName);
    //     return true;
    // }

    /// <summary>
    /// The private SpreadsheetCell class that is the implementation of the Cell class
    /// We'll be using this inside the Spreadsheet to make our cells
    /// </summary>
    private class SpreadsheetCell(int row, int col) : Cell(row, col), INotifyPropertyChanged
    {
        /// <summary>
        /// Sets value with val
        /// </summary>
        /// <param name="val"></param>
        public void SetValue(string val)
        {
            this.value = val;
        }
    }
}