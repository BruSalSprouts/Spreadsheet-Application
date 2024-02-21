using System;
using System.Linq.Expressions;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Spreadsheet_Bruno_Sanchez.ViewModels;

namespace Spreadsheet_Bruno_Sanchez.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class. Sets up the ViewModel
    /// </summary>
    public MainWindow()
    {
        // Initializes the whole window
        this.InitializeComponent();
        
        // Creates the first row of text columns
        this.WhenAnyValue(x => x.DataContext)
            .Where(dataContext => dataContext != null)
            .Subscribe(dataContext =>
            {
                if (dataContext is MainWindowViewModel)
                {
                    // The part of the row that makes every Data Grid Cell
                    InitializeDataGrid();
                }
            });
    }

    private void InitializeDataGrid()
    {
        // this.SpreadsheetDataGrid.Columns.Add(new DataGridTextColumn()); Added or removed as time goes on
        // this.SpreadsheetDataGrid.LoadingRow += this.AddRowNumbers;
        for (char name = 'A'; name <= 'Z'; name++)
        {
            var col = new DataGridTextColumn();
            col.Header = name;
            this.SpreadsheetDataGrid.Columns.Add(col);
        }
        
    }
    // public void AddRowNumbers(object sender, DataGridRowEventArgs e)
    // {
    //     e.Row.Header = (e.Row.GetIndex() + 1).ToString();
    // }
}