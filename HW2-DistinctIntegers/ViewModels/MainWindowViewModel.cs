using System.Collections.Generic;
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
    /// <summary>
    /// The main dialogue of the application. It also creates an int list of numbers from 0 - 20K with a size of 10K 
    /// This is where the dialogue string is gathered and put together via a StringBlock
    /// </summary>
    /// <returns>The dialogue in the form of a singular string, just a big one at that</returns>
    private string RunDistinctIntegers()
    {
        var rand = new Random();
        List<int> numbers = new List<int>();
        StringBuilder responseString = new StringBuilder("");
        for (int i = 0; i < 10000; i++) //Makes the list that's has a size of 10K ints
        {
            numbers.Add(rand.Next(0, 20000));
        }
        responseString.AppendLine("Method 1: Hash Set method: " + HashMethod(numbers) + " unique numbers");
        responseString.AppendLine(
            "The time complexity is O(N), as it iterates through every item in the list once, \n" +
            "meaning it'll search through N items, given that N is the amount of items in the list, \n" +
            "which leads to O(N) time complexity");
        responseString.AppendLine("Method 2: O(1) Storage method: " + OOneMethod(numbers) + " unique numbers");
        responseString.AppendLine("Method 3: Sorted method: " + SortingMethod(numbers) + " unique numbers");
        //Converting the StringBuild response to a string and returning that
        return responseString.ToString();
        // return "Hello World";
    }
    /// <summary>
    /// Takes in an int list, adds all elements to a Hash Set, and returns the size of the Hash set
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns>int</returns>
    public static int HashMethod(List<int> numbers)
    {
        HashSet<int> hashNums = new HashSet<int>();
        for (int i = 0; i < numbers.Count; i++)
        {
            hashNums.Add(numbers[i]); //All items in numbers list get added, and duplicates don't count
        }
        return hashNums.Count; //Return size of hash map,
    }
    /// <summary>
    /// Takes in an int list and iterates through the list for each element to see if there are any duplicates
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns>int</returns>
    public static int OOneMethod(List<int> numbers)
    {
        int numListSize = numbers.Count;
        int uniqueItems = numListSize; //Number of distinct items starts as size of list, will go down
        for (int i = 0; i < numListSize; i++)
        {
            for (int k = i + 1; k < numListSize; k++) //Double for loop, iterates through list for each item
            {
                if (numbers[i] == numbers[k]) //If there's a duplicate item
                {
                    uniqueItems--; //Decrease total number of unique items by 1
                    break;
                }
            }
        }
        return uniqueItems;
    }
    /// <summary>
    /// Takes in an int list, sorts it, and iterates through it looking for duplicates while adding to a total for each jump.
    /// If any duplicates are found, the iteration increases by 1 until the comparison is no longer true.
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns>int</returns>
    public static int SortingMethod(List<int> numbers)
    {
        numbers.Sort(); // Sorting list
        int numSize = numbers.Count;
        int total = 0;
        for (int i = 0; i < numSize; i++)
        {
            while (i < numSize - 1 && numbers[i] == numbers[i + 1])
            {  // If any duplicate items are next to each other, we'll skip those duplicates
                i++;
            }
            total++; //Incremented number of distinct elements
        }
        return total;
    }
    
    public string Greeting { get; set; }
#pragma warning restore CA1822 // Mark members as static
}