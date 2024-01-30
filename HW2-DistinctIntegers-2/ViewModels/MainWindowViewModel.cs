using System;
using System.Collections.Generic;

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
        Random rand = new Random();
        List<int> numbers = new List<int>();
        return "Test";
    }
    
    public string Greeting { get; set; }
    
#pragma warning restore CA1822 // Mark members as static
}