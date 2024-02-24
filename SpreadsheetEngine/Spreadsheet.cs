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

    public Spreadsheet(int rowNum, int colNum) 
    {
        if (rowNum < 1)
        {
            throw new ArgumentOutOfRangeException("rowNum should be positive!");
        }
        if (colNum < 1)
        {
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
        {
            throw new IndexOutOfRangeException("The rows and columns have to be within range!");
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

    private void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        this.CellPropertyChanged?.Invoke(sender, e);
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
        /// Publicly gets or Protectedly sets to make the Value property
        /// </summary>
        protected string Value
        {
            get => this.Value;
            set => this.Value = value;
        }
    }
}