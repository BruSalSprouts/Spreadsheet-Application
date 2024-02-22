using System;
using System.Data.Common;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Spreadsheet_Bruno_SanchezParra.ViewModels;

namespace Spreadsheet_Bruno_SanchezParra.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenAnyValue(x => x.DataContext)
            .Where(dataContext => dataContext != null)
            .Subscribe(dataContext =>
            {
                if (dataContext is MainWindowViewModel)
                {
                    InitializeDataGrid();
                }
            });
    }

    private void InitializeDataGrid()
    {
        // Assuming there's the DataGrid in the XAML file named SpreadsheetDataGrid
        DataGrid? grid = this.FindControl<DataGrid>("SpreadsheetDataGrid");

        // Clear any pre-existing columns as a safeguard
        grid?.Columns.Clear();

        // Time to create the columns A - Z
        for (char colName = 'A'; colName <= 'Z'; colName++)
        {
            DataGridTemplateColumn col = new DataGridTemplateColumn();
            col.Header = colName.ToString();
            grid?.Columns.Add(col);
        }
    }
}