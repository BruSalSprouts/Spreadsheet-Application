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
    private List<List<SpreadsheetCell>> cells; 
        
    public Spreadsheet(int rowNum, int colNum) 
    {
        this.rows = rowNum;
        this.columns = colNum;
        this.cells = new List<List<SpreadsheetCell>>();
    }

    /// <summary>
    /// The private SpreadsheetCell class that is the implementation of the Cell class
    /// We'll be using this inside the Spreadsheet to make our cells
    /// </summary>
    private class SpreadsheetCell : Cell, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

        public SpreadsheetCell(int rows, int cols)
            : base(rows, cols)
        {
        }
        
        /// <summary>
        /// Gets or sets makes RowIndex property
        /// </summary>
        public int RowIndex { get; }
    
        /// <summary>
        /// Gets or sets makes ColumnIndex property
        /// </summary>
        public int ColumnIndex { get; }

        /// <summary>
        /// Publicly gets or Protectedly sets to make the Value property
        /// </summary>
        public string Value
        {
            get => this.Value;
            private set => this.Value = value;
        }

        /// <summary>
        /// Gets or sets makes Text property
        /// </summary>
        protected string Text
        {
            get => this.Text; // Getter
            set // Setter
            {
                // Conditional to ignore if new value is same as old value
                if (!string.Equals(this.Text, value, StringComparison.Ordinal))
                {
                    this.Text = value;

                    // Event handler for if text changes
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(this.Text)));
                }
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
    
}