using ReactiveUI;
using SpreadsheetEngine;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

public class CellViewModel : ViewModelBase
{
    protected readonly Cell cell;

    private bool canEdit;

    /// <summary>
    ///   Indicates if a cell is selected.
    /// </summary>
    private bool isSelected;

    public Cell Cell => this.cell;

    public CellViewModel(Cell cell)
    {
        this.cell = cell;
        this.isSelected = false;
        this.canEdit = false;
        // We forward the notifications from the cell model to the view model
        // note that we forward using args.PropertyName because Cell and CellViewModel properties have the same
        // names to simplify the procedure. If they had different names, we would have a more complex implementation to
        // do the property names matching
        this.cell.PropertyChanged += (sender, args) => { this.RaisePropertyChanged(args.PropertyName); };
    }

    public bool IsSelected
    {
        get => this.isSelected;
        set => this.RaiseAndSetIfChanged(ref this.isSelected, value);
    }

    public bool CanEdit
    {
        get => this.canEdit;
        set => this.RaiseAndSetIfChanged(ref this.canEdit, value);
    }

    public virtual string? Text
    {
        get => this.cell.Text;
        set => this.cell.Text = value;
    }

    public virtual string? Value => this.cell.Value;

    public virtual uint BackgroundColor
    {
        get => this.cell.BgColor;
        set => this.cell.BgColor = value;
    }
}