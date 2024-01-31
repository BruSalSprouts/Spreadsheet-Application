using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW2_DistinctIntegers.ViewModels;
using System;
public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public MainWindowViewModel()
    {
        Greeting = RunDistinctIntegers();
    }

    private string RunDistinctIntegers()
    {
        var rand = new Random();
        List<int> numbers = new List<int>();
        StringBuilder responseString = new StringBuilder("");
        for (int i = 0; i < 10000; i++)
        {
            numbers.Add(rand.Next(0, 20000));
        }
        int numListSize = numbers.Count;
        
        
        //Converting the StringBuild response to a string and returning that
        // return responseString.ToString();
        return "Hello World";
    }

    public static int hashMethod(List<int> numbers)
    {
        return 0;
    }

    public static int oOneMethod(List<int> numbers)
    {
        return 0;
    }

    public static int sortingMethod(List<int> numbers)
    {
        return 0;
    }
    
    public string Greeting { get; set; }
#pragma warning restore CA1822 // Mark members as static
}