using System;
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

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class with InitializeSpreadsheet.
    /// </summary>
    public MainWindowViewModel()
    {
        this.SpreadsheetData = [];
        this.spreadsheet = new Spreadsheet(RowCount, ColumnCount);
        foreach (var rowInd in Enumerable.Range(0, RowCount))
        {
            var columns = new List<Cell>(ColumnCount);
            foreach (var columnInd in Enumerable.Range(0, ColumnCount))
            {
                columns.Add(this.spreadsheet.GetCell(rowInd, columnInd));
            }

            this.SpreadsheetData.Add(columns);
        }
    }

    public void DoDemoHw()
    {
        
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
                columns.Add(this.spreadsheet.GetCell(rowInd, columnInd));
            }

            this.SpreadsheetData.Add(columns);
        }

        // We'll see to this part later
        // _spreadsheet = new Spreadsheet(rowCount: rowCount, columnCount: columnCount);

        // this.spreadsheetData = new List<List<(char column, string value)>>(rowCount);
        // foreach (var rowIndex in Enumerable.Range(0, rowCount))
        // {
        //     var columns = new List<(char column, string value)>(columnCount);
        //     foreach (var columnIndex in Enumerable.Range(0, columnCount))
        //     {
        //         columns.Add(((char)rowIndex, columnIndex));
        //     }
        //
        //     spreadsheetData.Add(columns);
        // }
    }
}