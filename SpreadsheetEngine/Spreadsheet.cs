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
    private int rows;
    private int columns;
    private SpreadsheetCell[,] cells; 

    public Spreadsheet(int rowNum, int colNum) 
    {
        this.Columns = colNum;
        this.Rows = rowNum;
        this.cells = new SpreadsheetCell[rowNum, colNum];
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
        throw new NotImplementedException();
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
    /// The private SpreadsheetCell class that is the implementation of the Cell class
    /// We'll be using this inside the Spreadsheet to make our cells
    /// </summary>
    private class SpreadsheetCell(int rows, int cols) : Cell(rows, cols), INotifyPropertyChanged
    {
        /// <summary>
        /// Gets makes RowIndex property
        /// </summary>
        public new int RowIndex { get; }

        /// <summary>
        /// Gets makes ColumnIndex property
        /// </summary>
        public new int ColumnIndex { get; }

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