// <copyright file="Parser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable SA1200
using System.Text;
#pragma warning restore SA1200

namespace SpreadsheetEngine;

/// <summary>
/// The Parser class. The ultimate goal is to parse a string but including delimiters as their own strings.
/// </summary>
public class Parser
{
    // private static readonly char[] delimiterChars = ['+', '-', '*', '/']; // Delimiters for expression.
    private static readonly HashSet<char> DelimiterChars = ['+', '-', '*', '/'];

    /// <summary>
    /// Initializes a new instance of the <see cref="Parser"/> class.
    /// </summary>
    public Parser()
    {
    }

    /// <summary>
    /// Takes in a line of text and returns a list of strings that includes the delimiters as their own
    /// strings within the list.
    /// </summary>
    /// <param name="line">string.</param>
    /// <returns>List of strings.</returns>
    public List<string> Parse(string line)
    {
        var pieces = new List<string>();
        var sb = new StringBuilder();
        foreach (var c in line)
        {
            if (DelimiterChars.Contains(c))
            {
                pieces.Add(sb.ToString());
                pieces.Add(c.ToString());
                sb.Clear();
            }
            else
            {
                sb.Append(c);
            }
        }

        if (sb.Length > 0)
        {
            pieces.Add(sb.ToString());
        }

        return pieces;
    }
}