// <copyright file="SpreadsheetConstructorTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// Name: Bruno Sanchez
// WSU ID: 11714424
namespace Spreadsheet_Testing;

using System;
using SpreadsheetEngine;

/// <summary>
/// The Tests to see if the Spreadsheet properly is constructed.
/// </summary>
public class SpreadsheetConstructorTests
{
    /// <summary>
    /// Setup for SpreadsheetConstructorTests.
    /// </summary>
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Tests to see if invalid parameters cause a Spreadsheet's initialization to fail.
    /// </summary>
    [Test]
    public void ConstructorInvalid1()
    {
        try
        {
            var e = new Spreadsheet(0, 0);
            Assert.Fail();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.ToString());
            Assert.Pass();
        }
    }

    /// <summary>
    /// Tests to see if invalid parameters cause a Spreadsheet's initialization to fail.
    /// </summary>
    [Test]
    public void ConstructorInvalid2()
    {
        try
        {
            var e = new Spreadsheet(-3, -39);
            Assert.Fail();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.ToString());
            Assert.Pass();
        }
    }

    /// <summary>
    /// Tests to see if a Spreadsheet can be created.
    /// </summary>
    [Test]
    public void ConstructorValid1()
    {
        try
        {
            var e = new Spreadsheet(50, 26);
            Assert.Pass();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.ToString());
            Assert.Fail();
        }
    }
}