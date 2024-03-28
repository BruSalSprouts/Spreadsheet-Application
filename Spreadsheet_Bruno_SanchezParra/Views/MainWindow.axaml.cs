// ReSharper disable RedundantUsingDirective
// <copyright file="MainWindow.axaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Spreadsheet_Bruno_SanchezParra.ViewModels;
using SpreadsheetEngine;

namespace Spreadsheet_Bruno_SanchezParra.Views;

/// <summary>
/// MainWindow Class.
/// </summary>
public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    private bool isInitialized;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        this.isInitialized = false;
        this.InitializeComponent();
        this.SpreadsheetDataGrid.HeadersVisibility = DataGridHeadersVisibility.All;
        this.WhenAnyValue(x => x.DataContext)
            .Where(dataContext => dataContext != null)

            // ReSharper disable once BadParensLineBreaks
            .Subscribe(dataContext =>
            {
                if (dataContext is MainWindowViewModel)
                {
                    this.InitializeDataGrid();
                }
            });
    }

    /// <summary>
    /// Binding handler which creates the Row Headers.
    /// </summary>
    /// <param name="sender">nullable object.</param>
    /// <param name="e">DataGridRowEventArgs.</param>
    private static void MainGridOnLoadingRow(object? sender, DataGridRowEventArgs e)
    {
        var row = e.Row;
        row.Header = (row.GetIndex() + 1).ToString();
        var color1 = new SolidColorBrush(Colors.CornflowerBlue); // First color for Spreadsheet
        var color2 = new SolidColorBrush(Colors.DarkSlateBlue); // Second color for Spreadsheet

        // row.Background = (row.GetIndex() % 2 == 0) ? new SolidColorBrush(0xffe0e0e0) : new SolidColorBrush(0xffd0d0d0);
        row.Background = row.GetIndex() % 2 == 0 ? color1 : color2;
    }

    /// <summary>
    /// Creates a row of cell columns that have headers that go from A - Z.
    /// </summary>
    private void InitializeDataGrid()
    {
        if (this.isInitialized)
        { // Stops initialization in case this is called again for some reason
            return;
        }

        // Assuming there's the DataGrid in the XAML file named SpreadsheetDataGrid
        // var grid = this.FindControl<DataGrid>("SpreadsheetDataGrid");
        var grid = this.SpreadsheetDataGrid;

        // Clear any pre-existing columns as a safeguard
        grid.Columns.Clear();

        // Time to create the columns A - Z
        for (var colName = 'A'; colName <= 'Z'; colName++)
        {
            // var col = new DataGridTextColumn();
            // col.Header = colName.ToString();
            // col.Binding = new Binding($"[{colName - 'A'}].Value");
            // grid?.Columns.Add(col);
            var name = colName;
            var columnTemplate = new DataGridTemplateColumn
            {
                Header = colName.ToString(),
                CellTemplate = new FuncDataTemplate<List<Cell>>(
                    (
                        value,
                        namescope) => new TextBlock
                    {
                        [!TextBlock.TextProperty] =
                            new Binding($"[{name - 'A'}].Value"),
                        TextAlignment = TextAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        Text = value[name - 'A'].Value,
                        Padding = Thickness.Parse("5,0,5,0"),
                        IsVisible = true,
                    }),
                CellEditingTemplate = new FuncDataTemplate<List<Cell>>(
                    (
                    value,
                    namescope) => new TextBox

                    // Already bound to the Cell Block
                {
                    TextAlignment = TextAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Text = value[name - 'A'].Text, // Change the text in spreadsheet, updates cell here.
                    Padding = Thickness.Parse("5,0,5,0"),
                    IsVisible = true,
                }),
                IsReadOnly = false,
            };
            columnTemplate.IsReadOnly = false;
            grid?.Columns.Add(columnTemplate);
        }

        if (grid != null)
        { // Row event handler
            grid.LoadingRow += MainGridOnLoadingRow;
        }

        this.isInitialized = true;
    }

    /// <summary>
    /// Event handler so every time a Cell is clicked on, the row is highlighted and ultimately the cell's Text
    /// contents are copied to MyText.Text.
    /// </summary>
    /// <param name="sender">nullable object.</param>
    /// <param name="e">DataGridCellPointerPressedEventArgs.</param>
    private void MainGridOnCellPointerPressed(object? sender, DataGridCellPointerPressedEventArgs e)
    {
        if (sender == null)
        {
            return;
        }

        var dg = (DataGrid)sender;
        var row = e.Row.GetIndex();

        // ReSharper disable once NullableWarningSuppressionIsUsed
        var col = e.Column.Header.ToString() ![0] - 'A';
        var cells = (List<List<Cell>>)dg.ItemsSource;
        var cell = cells[row][col];
        this.MyText.Text = $"[{e.Column.Header}{row + 1}] : {cell.Text}";
    }

    /// <summary>
    /// Event handler for when a cell is preparing to edit it's contents.
    /// </summary>
    /// <param name="sender">object.</param>
    /// <param name="e">DataGridCellEditEndingEventArgs.</param>
    private void SpreadsheetDataGrid_OnPreparingCellForEdit(object? sender, DataGridPreparingCellForEditEventArgs e)
    {
    }

    /// <summary>
    /// Event handler for when a cell has finished editing it's text contents.
    /// </summary>
    /// <param name="sender">object.</param>
    /// <param name="e">DataGridCellEditEndingEventArgs.</param>
    private void SpreadsheetDataGrid_OnCellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
    {
        var vm = this.ViewModel;
        var block = (TextBox)e.EditingElement;
        var dg = (DataGrid)sender!;
        int row = e.Row.GetIndex();
        if (vm != null && e.Column != null && block.Text != null)
        {
            int? col = e.Column?.Header?.ToString()?[0] - 'A';
            if (col.HasValue && row < vm.SpreadsheetData.Count && col < vm.SpreadsheetData[0].Count)
            {
                vm.SetCellText(row, (int)col, block.Text);
            }
        }
    }
}