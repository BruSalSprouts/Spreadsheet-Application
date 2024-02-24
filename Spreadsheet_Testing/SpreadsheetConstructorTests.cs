namespace Spreadsheet_Testing;

using System;
using SpreadsheetEngine;
public class SpreadsheetConstructorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructorInvalid1()
    {
        try
        {
            Spreadsheet e = new Spreadsheet(0, 0);
            Assert.Fail();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.ToString());
            Assert.Pass();
        }
    }

    [Test]
    public void ConstructorInvalid2()
    {
        try
        {
            Spreadsheet e = new Spreadsheet(-3, -39);
            Assert.Fail();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.ToString());
            Assert.Pass();
        }
    }

    [Test]
    public void ConstructorValid1()
    {
        try
        {
            Spreadsheet e = new Spreadsheet(50, 26);
            Assert.Pass();
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.ToString());
            Assert.Fail();
        }
    }
}