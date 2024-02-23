using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SpreadsheetEngine;

public abstract class Cell : INotifyPropertyChanged
{
    // The Event Handler part
    public event PropertyChangedEventHandler? PropertyChanged = delegate { };

    // Fields for later properties
    protected string text;
    protected string value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Cell"/> class.
    /// </summary>
    /// <param name="rows" />
    /// <param name="cols" />
    /// <param name="text" />
    protected Cell(int rows, int cols)
    {
        this.RowIndex = rows;
        this.ColumnIndex = cols;
    }

    /// <summary>
    /// Gets or sets makes RowIndex property
    /// </summary>
    public int RowIndex { get; set; }

    /// <summary>
    /// Gets or sets makes ColumnIndex property
    /// </summary>
    public int ColumnIndex { get; set; }

    /// <summary>
    /// Gets or sets makes Text property
    /// </summary>
    public string Text
    {
        get => this.text; // Getter
        set // Setter
        {
            // Conditional to ignore if new value is same as old value
            if (!string.Equals(this.text, value, StringComparison.Ordinal))
            {
                this.text = value;

                // Event handler for if text changes
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Text)));
            }
        }
    }

    /// <summary>
    /// Publicly gets or Protectedly sets to make the Value property
    /// </summary>
    public string Value
    {
        get => this.value;
        protected internal set => this.value = value;
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