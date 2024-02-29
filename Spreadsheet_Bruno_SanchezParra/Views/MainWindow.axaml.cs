using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SpreadsheetEngine;
using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        this.InitializeComponent();
        this.SpreadsheetDataGrid.HeadersVisibility = DataGridHeadersVisibility.All;
        this.WhenAnyValue(x => x.DataContext)
            .Where(dataContext => dataContext != null)
            .Subscribe(dataContext =>
            {
                if (dataContext is MainWindowViewModel)
                {
                    this.InitializeDataGrid();
                }
            });
    }

    /// <summary>
    /// Creates a row of cell columns that have headers that go from A - Z
    /// </summary>
    private void InitializeDataGrid()
    {
        // Assuming there's the DataGrid in the XAML file named SpreadsheetDataGrid
        var grid = this.FindControl<DataGrid>("SpreadsheetDataGrid");

        // Clear any pre-existing columns as a safeguard
        grid?.Columns.Clear();

        // Time to create the columns A - Z
        for (char colName = 'A'; colName <= 'Z'; colName++)
        {
            var col = new DataGridTextColumn();
            col.Header = colName.ToString();
            col.Binding = new Binding($"[{colName - 'A'}].Value");
            grid?.Columns.Add(col);
        }

        if (grid != null)
        {
            grid.LoadingRow += MainGridOnLoadingRow;
        }
    }

    private static void MainGridOnLoadingRow(object? sender, DataGridRowEventArgs e)
    {
        var row = e.Row;
        row.Header = (row.GetIndex() + 1).ToString();
        var color1 = new SolidColorBrush(Colors.CornflowerBlue); // First color for Spreadsheet
        var color2 = new SolidColorBrush(Colors.DarkSlateBlue); // Second color for Spreadsheet
        // row.Background = (row.GetIndex() % 2 == 0) ? new SolidColorBrush(0xffe0e0e0) : new SolidColorBrush(0xffd0d0d0);
        row.Background = (row.GetIndex() % 2 == 0) ? color1 : color2;

    }

    private void MainGridOnCellPointerPressed(object? sender, DataGridCellPointerPressedEventArgs e)
    {
        var dg = (DataGrid)sender!;
        int row = e.Row.GetIndex();
        int col = e.Column.Header.ToString()[0] - 'A';
        var cells = (List<List<Cell>>)dg.ItemsSource;
        var cell = cells[row][col];
        this.MyText.Text = $"[{e.Column.Header}{row+1}] : {cell.Text}";
    }
}