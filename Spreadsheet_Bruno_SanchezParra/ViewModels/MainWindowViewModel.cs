// <copyright file="MainWindowViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Input;
using Avalonia.Media;
using ReactiveUI;
using Spreadsheet_Bruno_SanchezParra.Commands;
using SpreadsheetEngine;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

/// <summary>
/// MainWindowViewModel class. Here is where it takes logic from SpreadsheetEngine and does stuff with it.
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    private const int RowCount = 50;
    private const int ColumnCount = 'Z' - 'A' + 1;

    // CellViewModel related stuff.
    private readonly List<CellViewModel> selectedCells = [];

    // The Spreadsheet itself.
    private Spreadsheet spreadsheet;

    // Booleans that tell View if it can redo and undo stuff.
    private bool redoEnabled;
    private bool undoEnabled;

    /// <summary>
    /// Gets or sets a value indicating whether it gets or sets the RedoEnabled property.
    /// </summary>
    public bool RedoEnabled
    {
        get => this.redoEnabled;
        set => this.RaiseAndSetIfChanged(ref this.redoEnabled, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether it gets or sets the UndoEnabled property.
    /// </summary>
    public bool UndoEnabled
    {
        get => this.undoEnabled;
        set => this.RaiseAndSetIfChanged(ref this.undoEnabled, value);
    }

    /// <summary>
    /// Gets UndoCommand property.
    /// </summary>
    public ICommand UndoCommand { get; }

    /// <summary>
    /// Gets RedoCommand property.
    /// </summary>
    public ICommand RedoCommand { get; }

    /// <summary>
    /// Gets ChooseColorCommand property.
    /// </summary>
    public ICommand ChooseColorCommand { get; }

    /// <summary>
    /// Gets ShowDialog property.
    /// </summary>
    public Interaction<ColorChooserViewModel, ChooserViewModel?> ShowDialog { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class with InitializeSpreadsheet.
    /// </summary>
    public MainWindowViewModel()
    {
        // Spreadsheet data initialization
        this.SpreadsheetData = [];
        this.InitializeSpreadsheet();

        // Undo and Redo Enabling fields
        this.RedoEnabled = false;
        this.UndoEnabled = false;

        // Undo and Redo command Initialization
        this.UndoCommand = ReactiveCommand.Create(
            () =>
            {
                CommandController.GetInstance().Undo();

                // Gets redo and undo commands set up here.
                this.UndoEnabled = CommandController.GetInstance().UndoStackEnabled();
                this.RedoEnabled = CommandController.GetInstance().RedoStackEnabled();
            });
        this.RedoCommand = ReactiveCommand.Create(
            () =>
            {
                CommandController.GetInstance().Redo();

                // Gets redo and undo commands set up here.
                this.UndoEnabled = CommandController.GetInstance().UndoStackEnabled();
                this.RedoEnabled = CommandController.GetInstance().RedoStackEnabled();
            });

        // Color Picker Initialization
        this.ShowDialog = new Interaction<ColorChooserViewModel, ChooserViewModel?>();
        var defaultColor = Colors.White;
        this.ChooseColorCommand = ReactiveCommand.Create(
            async () =>
            {
                if (this.selectedCells.Count > 0)
                {
                    defaultColor = Color.FromUInt32(this.selectedCells[0].BackgroundColor);
                }

                var chooser = new ColorChooserViewModel(defaultColor);
                var result = await this.ShowDialog.Handle(chooser);
                if (result != null)
                {
                    foreach (var cell in this.selectedCells)
                    {
                        var colorHolder = result.Colour;

                        // Make sure alpha channel is ignored by masking it with 0xFF000000
                        CommandController.GetInstance().InvokeChange(
                            cell,
                            nameof(CellViewModel.BackgroundColor),
                            colorHolder.ToUInt32() | 0xFF000000);

                        // Gets redo and undo commands set up here.
                        this.UndoEnabled = CommandController.GetInstance().UndoStackEnabled();
                        this.RedoEnabled = CommandController.GetInstance().RedoStackEnabled();
                    }
                }
            });
    }

    // /// <summary>
    // /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
    // /// </summary>
    // /// <param name="spreadsheetData">list of list of Cells.</param>
    // // ReSharper disable once UnusedMember.Global
    // public MainWindowViewModel(List<RowViewModel> spreadsheetData)
    // {
    //     this.SpreadsheetData = spreadsheetData;
    // }

    /// <summary>
    /// Gets or sets spreadsheetData.
    /// </summary>
    public List<RowViewModel> SpreadsheetData { get; set; }

    /// <summary>
    /// Gets the Rows Property.
    /// </summary>
    // ReSharper disable once UnassignedGetOnlyAutoProperty - Asked for from Assignment.
    public Cell[][] Rows { get; }

    /// <summary>
    /// Gets the RowAmount Property.
    /// </summary>
    public int RowAmount { get; } = RowCount;

    /// <summary>
    /// The Event handler for the HW Demo Button. For each cell it clears text, if it's column A it sets the Value to
    /// Whatever is in column B of that row, if it's column B it sets the Text and value to Hello World with the
    /// related row int, otherwise it has a random chance of setting that cell's Value to a shrug emoji with a number
    /// indicator to show that it's happened 50 times, upon which that chance will no longer happen.
    /// </summary>
    public void DoDemoHw()
    {
        var totalRandom = 0;
        var random = new Random(); // The random class being started
        for (var row = 0; row < RowCount; row++)
        {
            for (var col = 0; col < ColumnCount; col++)
            {
                this.spreadsheet[row, col].Text = string.Empty; // Clears the cell's Text so we can start fresh here
                switch (col)
                {
                    case 0: // Sets Text to whatever is in Column B of that respective Cell
                        this.spreadsheet[row, col].Text = $"={(char)(col + 'A' + 1)}{row + 1}";
                        break;
                    case 1: // Sets it to Hello World {row header int}
                        this.spreadsheet[row, col].Text = $"Hello from B{row + 1:d2}!";
                        break;
                    default:
                    {
                        // Random chance of setting a cell to the emoji, unless it's been done 50 times now
                        if (random.Next(0, 20) >= 18 && totalRandom < 50)
                        {
                            this.spreadsheet[row, col].Text = $"\u00af\\_(ツ)_/\u00af #{++totalRandom}";
                        }

                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Gets the cell from SpreadsheetData's ViewModels.
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">integer.</param>
    /// <returns>Cell.</returns>
    public Cell GetCell(int row, int col)
    {
        return this.SpreadsheetData[row][col].Cell;
    }

    /// <summary>
    /// Gets the CellViewModel from SpreadsheetData's ViewModels.
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">integer.</param>
    /// <returns>CellViewModel.</returns>
    public CellViewModel GetCellModel(int row, int col)
    {
        return this.SpreadsheetData[row][col];
    }

    /// <summary>
    /// Sets a cell's text.
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">integer.</param>
    /// <param name="value">string.</param>
    public void SetCellText(int row, int col, string value)
    {
        this.SpreadsheetData[row][col].Text = value;
    }

    /// <summary>
    /// Selects a Cell.
    /// </summary>
    /// <param name="rowIndex">int.</param>
    /// <param name="colIndex">integer.</param>
    public void SelectCell(int rowIndex, int colIndex)
    {
        var clickedCell = this.GetCellModel(rowIndex, colIndex);
        var shouldEditCell = clickedCell.IsSelected;
        this.ResetSelection();

        // Add the pressed cell back to the list
        this.selectedCells.Add(clickedCell);

        clickedCell.IsSelected = true;
        if (shouldEditCell)
        {
            clickedCell.CanEdit = true;
        }
    }

    /// <summary>
    /// Resets all selected cells to false.
    /// </summary>
    public void ResetSelection()
    {
        // Clear currents election
        foreach (var cell in this.selectedCells)
        {
            cell.IsSelected = false;
            cell.CanEdit = false; // Needs to be set to false for something later.
        }

        this.selectedCells.Clear();
    }

    /// <summary>
    /// Toggles whether a cell is selected or not.
    /// </summary>
    /// <param name="rowIndex">int.</param>
    /// <param name="colIndex">integer.</param>
    public void ToggleCellSelection(int rowIndex, int colIndex)
    {
        var clickedCell = this.GetCellModel(rowIndex, colIndex);
        if (clickedCell.IsSelected == false)
        {
            this.selectedCells.Add(clickedCell);
            clickedCell.IsSelected = true;
        }
        else
        {
            this.selectedCells.Remove(clickedCell);
            clickedCell.IsSelected = false;
        }
    }

    /// <summary>
    /// Gets a cell's text.
    /// </summary>
    /// <param name="row">int.</param>
    /// <param name="col">integer.</param>
    /// <returns>string.</returns>
    public string GetCellText(int row, int col)
    {
        return this.SpreadsheetData[row][col].Cell.Text;
    }

    /// <summary>
    /// Clears all the cells in the Spreadsheet by setting all their Texts to string.Empty.
    /// </summary>
    public void ClearSpreadsheet()
    {
        this.RedoEnabled = false;
        this.UndoEnabled = false;
        CommandController.GetInstance().ClearStacks();

        foreach (var cell in this.SpreadsheetData.SelectMany(row => row.Cells))
        {
            cell.Text = string.Empty;
            cell.BackgroundColor = Colors.White.ToUInt32();
            cell.TextColor = Colors.Black.ToUInt32();
        }
    }

    /// <summary>
    /// Calls SaveToFile and passes stream.
    /// </summary>
    /// <param name="stream">Stream.</param>
    public void SaveData(Stream stream)
    {
        this.spreadsheet.SaveToFile(stream);
    }

    /// <summary>
    /// Calls LoadToFile and passes stream.
    /// </summary>
    /// <param name="stream">Stream.</param>
    public void LoadData(Stream stream)
    {
        this.spreadsheet.LoadFromFile(stream);
    }

    /// <summary>
    /// Initializes the spreadsheet by making rows of Cell class.
    /// (Temporary fix until then is a List of List of char and string).
    /// </summary>
    private void InitializeSpreadsheet()
    {
        this.SpreadsheetData = [];
        this.spreadsheet = new Spreadsheet(RowCount, ColumnCount);
        foreach (var rowInd in Enumerable.Range(0, RowCount))
        {
            var column = new List<CellViewModel>();
            foreach (var columnInd in Enumerable.Range(0, ColumnCount))
            {
                // var cellTemp = this.spreadsheet.GetCell(rowInd, columnInd);
                // cellTemp.Text = "test";
                var cell = this.spreadsheet.GetCell(rowInd, columnInd);
                column.Add(new CellViewModel(cell));
            }

            var newColumn = new RowViewModel(column);
            this.SpreadsheetData.Add(newColumn);
        }
    }
}