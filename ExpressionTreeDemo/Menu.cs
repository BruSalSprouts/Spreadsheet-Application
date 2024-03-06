// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
using SpreadsheetEngine;

namespace ExpressionTreeDemo;

/// <summary>
/// The menu class, where methods related to the Menu will be located.
/// </summary>
public class Menu
{
    // Entries for the menu
    private readonly List<string> entries =
    [
        "Enter a new Expression", "Set a variable value",
        "Evaluate Tree", "Quit"
    ];

    private string expression = string.Empty; // Expression that will be modified throughout the demo
    private ExpressionTree? tree = null; // The tree that will be made from _expression

    /// <summary>
    /// Displays the menu entries from list entries.
    /// </summary>
    public void DisplayMenu()
    {
        Console.Write("Menu");
        if (!string.IsNullOrEmpty(this.expression))
        {
            Console.Write($" (Current Expression: {this.expression})");
        }

        Console.WriteLine();
        var line = 0;
        foreach (var entry in this.entries)
        {
            Console.WriteLine($"{++line} = {entry}");
        }
    }

    /// <summary>
    /// Sets a new expression from user input. Does error handling if no input exists.
    /// </summary>
    private void AddExpression()
    {
        Console.Write("Enter a new valid expression: ");
        var line = Console.ReadLine();
        if (!string.IsNullOrEmpty(line))
        {
            this.expression = line;
            this.tree = new ExpressionTree(this.expression);
        }
        else
        {
            Console.WriteLine("No expression entered");
        }
    }

    /// <summary>
    /// Sets a variable within the expression to a new value. Prompts the user for both the variable name,
    /// then the new value.
    /// </summary>
    private void SetVariable()
    {
        if (this.tree == null)
        {
            Console.WriteLine("No expression set");
            return;
        }

        Console.Write("Enter variable name: ");
        var name = Console.ReadLine();
        if (!string.IsNullOrEmpty(name))
        {
            Console.Write("Enter value: ");
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && double.TryParse(input, out var value))
            {
                this.tree.SetVariable(name, value);
            }
            else
            {
                Console.WriteLine("Not a number");
            }
        }
        else
        {
            Console.WriteLine("No name was entered");
        }
    }

    /// <summary>
    /// Evaluates the expression tree.
    /// </summary>
    private void EvaluateTree()
    {
        if (this.tree == null)
        {
            Console.WriteLine("No expression set");
            return;
        }

        var value = this.tree.Evaluate();
        Console.WriteLine($"The evaluated answer is: {value}");
    }

    /// <summary>
    /// The menu functionality, from which the user can do one of the menu commands.
    /// </summary>
    /// <returns>bool.</returns>
    internal bool Execute()
    {
        var line = Console.ReadLine();
        if (!int.TryParse(line, out var option) || option is < 1 or > 4)
        {
            return false;
        }

        switch (option)
        {
            case 1:
                this.AddExpression();
                break;
            case 2:
                this.SetVariable();
                break;
            case 3:
                this.EvaluateTree();
                break;
            case 4:
                return true;
        }

        return false;
    }
}
