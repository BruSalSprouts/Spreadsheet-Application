namespace HW2_DistinctIntegers.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public MainWindowViewModel()
    {
        Greeting = RunDistinctIntegers();
    }

    private string RunDistinctIntegers()
    {
        return "Hello World!";
    }

    public string Greeting { get; set; }
#pragma warning restore CA1822 // Mark members as static
}