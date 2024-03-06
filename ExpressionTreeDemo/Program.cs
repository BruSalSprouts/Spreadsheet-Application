// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
namespace ExpressionTreeDemo;

/// <summary>
/// Console application class to demo the expression tree.
/// </summary>
public static class Program
{
    /// <summary>
    /// Main method from which the program will run.
    /// </summary>
    public static void Main()
    {
        var menu = new Menu();
        bool done;
        do
        {
            menu.DisplayMenu();
            done = menu.Execute();
        }
        while (!done);
    }
}