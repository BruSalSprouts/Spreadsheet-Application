using System.Collections.Generic;
using System.ComponentModel;
using ReactiveUI;

namespace Spreadsheet_Bruno_SanchezParra.ViewModels;

public class RowViewModel : ViewModelBase
{
    public RowViewModel(List<CellViewModel> cells)
    {
        this.Cells = cells;
        foreach (var cell in this.Cells)
        {
            cell.PropertyChanged += this.CellOnPropertyChanged;
        }

        this.SelfReference = this;
    }

    public CellViewModel this[int index] => this.Cells[index];

    private void CellOnPropertyChanged(object? sender, PropertyChangedEventArgs args)
    {
        var styleImpactingProperties = new List<string>
        {
            nameof(CellViewModel.IsSelected),
            nameof(CellViewModel.CanEdit),
            nameof(CellViewModel.BackgroundColor),
        };
        if (styleImpactingProperties.Contains(args.PropertyName))
            this.FireChangedEvent();
    }

    public List<CellViewModel> Cells { get; set; }

    /// <summary>
    /// This property provides a way to notify the value converter that it needs to update
    /// </summary>
    public RowViewModel SelfReference { get; private set; }

    public void FireChangedEvent()
    {
        this.RaisePropertyChanged(nameof(this.SelfReference));
    }
}