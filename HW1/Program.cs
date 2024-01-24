using System;
using System.Collections.Generic;
using HW1;

class Program : BST
{
    public static void Main()
    {
        string line = GetIntList();
        int len = line.Length;
        string[] numbersString = line.Split(' '); //Split string into string arrays, which will go into BST
        BST numbers = new BST();
        int temp = 0;
        foreach (string var in numbersString){ //The parsing itself 
            try
            {
                temp = int.Parse(var);
                numbers.Insert(temp);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Failed to convert '{var}' to an integer. Format is invalid.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Failed to convert '{var}' to an integer. Value is too large or too small.");
            }
        }
        Console.WriteLine("Here is the list of ordered items!");
        numbers.DisplayInOrder(); // Task 3
        //Task 4 tasks below
        int numNodes = numbers.NumItems();
        Console.WriteLine("\nThe total number of items is " + numNodes);
        int levelCount = numbers.GetLevels();
        Console.WriteLine("The total number of levels is " + levelCount);
        int numPotentialLevels = PotentialMinimumLevels(numNodes);
        Console.WriteLine("The total potential amount of levels with the number of items is " + numPotentialLevels);
        
    }
    /* Prompts user to type in a bunch of integer numbers with spaces in between, and returns the line typed in as a string */
    private static string GetIntList()
    {
        Console.WriteLine("Write a list of integer numbers");
        string line = Console.ReadLine();
        Console.WriteLine("You wrote " + line);
        if (string.IsNullOrEmpty(line))
        {
            return string.Empty;
        }
        return line;
    }

    private static int PotentialMinimumLevels(int numNodes)
    { 
        /*A binary tree with x amount of leaves has the following amount of leaves
         (Round down the answer to log_2(x)), add one to that answer.
         */
        double rawAnswer = Math.Log(numNodes, 2);
        double roundedAnswer = (Math.Floor(rawAnswer));
        return (int)roundedAnswer + 1;
    }
}