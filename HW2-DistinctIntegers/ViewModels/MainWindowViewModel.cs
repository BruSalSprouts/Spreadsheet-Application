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
        responseString.AppendLine("Method 1: Hash Set method: " + HashMethod(numbers) + " unique numbers");
        responseString.AppendLine(
            "The time complexity is O(N), as it iterates through every item in the list once, \n" +
            "meaning it'll search through N items, given that N is the amount of items in the list, \n" +
            "which leads to O(N) time complexity");
        responseString.AppendLine("Method 2: O(1) Storage method: " + OOneMethod(numbers) + " unique numbers");
        
        //Converting the StringBuild response to a string and returning that
        return responseString.ToString();
        // return "Hello World";
    }

    public static int HashMethod(List<int> numbers)
    {
        HashSet<int> hashNums = new HashSet<int>();
        for (int i = 0; i < numbers.Count; i++)
        {
            hashNums.Add(numbers[i]);
        }
        return hashNums.Count;
    }

    public static int OOneMethod(List<int> numbers)
    {
        int numListSize = numbers.Count;
        int uniqueItems = numListSize;
        for (int i = 0; i < numListSize; i++)
        {
            for (int k = i + 1; k < numListSize; k++)
            {
                if (numbers[i] == numbers[k])
                {
                    uniqueItems--;
                    break;
                }
            }
        }
        return uniqueItems;
    }

    public static int SortingMethod(List<int> numbers)
    {
        numbers.Sort();
        int total = 0;
        return total;
    }
    
    public string Greeting { get; set; }
#pragma warning restore CA1822 // Mark members as static
}