using System.Collections.Generic;
using System.Linq;
using ReactiveUI;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    // So since we don't yet have the Spreadsheet or Cell classes done, we'll just make the spreadsheets 
    // using lists for now
    private List<List<(char column, string value)>> spreadsheetData;

    /// <summary>
    /// This is the property of spreadsheetData.
    /// </summary>
    public List<List<(char Column, string Value)>> SpreadsheetData
    {
        get => this.spreadsheetData;
        set => this.RaiseAndSetIfChanged(ref this.spreadsheetData, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class with InitializeSpreadsheet.
    /// </summary>
    public MainWindowViewModel()
    {
        this.InitializeSpreadsheet();
    }

    /// <summary>
    /// Initializes the spreadsheet by making rows of Cell class.
    /// (Temporary fix until then is a List of List of char and string)
    /// </summary>
    private void InitializeSpreadsheet()
    {
        const int rowCount = 50;
        const int columnCount = 'Z' - 'A' + 1;

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