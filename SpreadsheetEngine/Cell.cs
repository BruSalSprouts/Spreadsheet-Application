using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SpreadsheetEngine;

public abstract class Cell : INotifyPropertyChanged
{
    // The Event Handler part
    public event PropertyChangedEventHandler? PropertyChanged = delegate { };

    protected string value;
    protected string text;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class.
    /// </summary>
    /// <param name="row" />
    /// <param name="col" />
    protected Cell(int row, int col)
    {
        this.ColumnIndex = col;
        this.RowIndex = row;
        this.text = string.Empty;
        this.value = string.Empty;
    }

    /// <summary>
    /// Gets the RowIndex property
    /// </summary>
    public int RowIndex { get; }

    /// <summary>
    /// Gets the ColumnIndex property
    /// </summary>
    public int ColumnIndex { get; }

    /// <summary>
    /// Gets or sets makes Text property
    /// </summary>
    public virtual string Text
    {
        get => this.text; // Getter
        set // Setter
        {
            // Conditional to ignore if new value is same as old value
            if (!string.Equals(this.text, value, StringComparison.Ordinal))
            {
                this.text = value;

                // Event handler for if text changes
                // this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Text)));
                this.OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Gets publicly gets or Protectedly sets to make the Value property
    /// </summary>
    public virtual string Value
    {
        get => this.value;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    // {
    //     if (EqualityComparer<T>.Default.Equals(field, value))
    //     {
    //         return false;
    //     }
    //
    //     field = value;
    //     this.OnPropertyChanged(propertyName);
    //     return true;
    // }
}