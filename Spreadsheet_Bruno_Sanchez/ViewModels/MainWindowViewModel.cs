using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Spreadsheet_Bruno_Sanchez.Models;

namespace Spreadsheet_Bruno_Sanchez.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    // public Spreadsheet Spread { get; set; }
    public ObservableCollection<List<Cell>> SpreadSheet { get; set; }

    public MainWindowViewModel()
    {
        this.InitializeSpreadsheet(); // This is where I'm calling InitializeSpreadshseet to add the rows
    }

    /// <summary>
    /// Initializes the rest of the spreadsheet, adding the rows for each of the columns.
    /// </summary>
    private void InitializeSpreadsheet()
    {
        const int rowCount = 50;
        const int columnCount = 'Z' - 'A' + 1;

        // The new spreadsheet is basically a list of list of Cell item, so we'll do just that
        List<List<Cell>> newSpreadsheet = new List<List<Cell>>(rowCount);

        // For each row...
        foreach (var rowIndex in Enumerable.Range(0, rowCount))
        {
            // Create a new column of cells that we'll insert into the row
            var columns = new List<Cell>(columnCount);
            foreach (var columnIndex in Enumerable.Range(0, columnCount))
            {
                // Adding the cells to the list
                columns.Add(new Cell($"{columnIndex}ABC"));
            }
            
            // Adds the column of cells to the row index
            newSpreadsheet.Add(columns);

            // _spreadsheetData.Add(columns);
        }

        // Adds the new spreadsheet to the overall spreadsheet to be shown
        this.SpreadSheet = new ObservableCollection<List<Cell>>(newSpreadsheet);
    }
}