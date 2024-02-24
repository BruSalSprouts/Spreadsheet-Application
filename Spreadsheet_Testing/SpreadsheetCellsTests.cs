namespace Spreadsheet_Testing;

using System;
using SpreadsheetEngine;
public class SpreadsheetCellsTests
{
    private Spreadsheet? spreadsheet;
    [SetUp]
    public void Setup()
    {
        this.spreadsheet = new Spreadsheet(5, 4);
    }

    [Test]
    public void ColumnTest()
    {
        int actual = spreadsheet.ColumnCount();
        Assert.That(actual, Is.EqualTo(4));
    }

    [Test]
    public void RowTest()
    {
        int actual = spreadsheet.RowCount();
        Assert.That(actual, Is.EqualTo(5));
    }

    [Test]
    public void GetCellTest1()
    {
        var cellActual = spreadsheet.GetCell(1, 1);
        Assert.NotNull(cellActual);
    }
    
    [Test]
    public void GetCellTestError1()
    {
        try
        {
            var cellActual = spreadsheet.GetCell(10, 10);
            Assert.Fail();
        }
        catch (IndexOutOfRangeException e)
        {
            Assert.Pass();
        }
    }
    [Test]
    public void GetCellTestError2()
    {
        try
        {
            var cellActual = spreadsheet.GetCell(-1, -10);
            Assert.Fail();
        }
        catch (IndexOutOfRangeException e)
        {
            Assert.Pass();
        }
    }
}