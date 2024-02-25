using System.ComponentModel;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Spreadsheet_Testing;

using System;
using SpreadsheetEngine;
public class SpreadsheetCellsTests
{
    private Spreadsheet? spreadsheet;
    private bool catcherCalled;
    [SetUp]
    public void Setup()
    {
        this.spreadsheet = new Spreadsheet(5, 4);
        catcherCalled = false;
    }

    [Test]
    public void ColumnTest()
    {
        int? actual = this.spreadsheet?.ColumnCount();
        Assert.That(actual, Is.EqualTo(4));
    }

    [Test]
    public void RowTest()
    {
        int? actual = this.spreadsheet?.RowCount();
        Assert.That(actual, Is.EqualTo(5));
    }

    [Test]
    public void GetCellTest1()
    {
        var cellActual = this.spreadsheet?.GetCell(1, 1);
        Assert.NotNull(cellActual);
    }
    
    [Test]
    public void GetCellTest2()
    {
        var cellActual = this.spreadsheet?.GetCell(4, 3);
        Assert.NotNull(cellActual);
        Assert.That(cellActual!.Text, Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetCellTest3()
    {
        var cellActual = this.spreadsheet?.GetCell(4, 3);
        if (cellActual != null)
        {
            cellActual.PropertyChanged += (sender, args) =>
            {
                Assert.That(args.PropertyName, Is.EqualTo("Text"));
                this.catcherCalled = true;
            };
            cellActual.Text = "test";
            Assert.That(cellActual!.Text, Is.EqualTo("test"));
            Assert.True(this.catcherCalled);
        }
    }

    [Test]
    public void EventTest1()
    {
        this.spreadsheet.CellPropertyChanged += (sender, args) =>
        {
            // Checks to see if sender is of type Cell
            Assert.True(sender is Cell);
            Cell cell = (Cell)sender;
            Assert.That(cell.Text, Is.EqualTo("test")); // An event fires!
        };
        var cellActual = this.spreadsheet?.GetCell(4, 3);
        if (cellActual != null)
        {
            cellActual.Text = "test";
        }
    }
    
    [Test]
    public void GetCellTestError1()
    {
        try
        {
            var cellActual = this.spreadsheet?.GetCell(10, 10);
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
            var cellActual = this.spreadsheet?.GetCell(-1, -10);
            Assert.Fail();
        }
        catch (IndexOutOfRangeException e)
        {
            Assert.Pass();
        }
    }

    [Test]
    public void FormulaTest1()
    {
        this.spreadsheet.GetCell(0, 0).Text = "hello";
        this.spreadsheet.GetCell(0, 1).Text = "=A1";
        Assert.That(this.spreadsheet.GetCell(0, 1).Value, Is.EqualTo("hello"));
    }
    
    [Test]
    public void FormulaTest2()
    {
        this.spreadsheet.GetCell(0, 0).Text = "hello";
        this.spreadsheet.GetCell(1, 2).Text = "=a1";
        Assert.That(this.spreadsheet.GetCell(1, 2).Value, Is.EqualTo("hello"));
    }
    
    [Test]
    public void FormulaTest3()
    {
        try
        {
            this.spreadsheet.GetCell(1, 2).Text = "=aA";
            Assert.Fail();
        }
        catch (FormatException f)
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public void FormulaTest4()
    {
        try
        {
            this.spreadsheet.GetCell(1, 2).Text = "=11";
            Assert.Fail();
        }
        catch (IndexOutOfRangeException f)
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public void FormulaTest5()
    {
        try
        {
            this.spreadsheet.GetCell(1, 2).Text = "=A0";
            Assert.Fail();
        }
        catch (IndexOutOfRangeException f)
        {
            Assert.Pass();
        }
    }
    
    [Test]
    public void FormulaTest6()
    {
        this.spreadsheet.GetCell(0, 0).Text = "hello";
        this.spreadsheet.GetCell(0, 0).Text = "=A1";
        Assert.That(this.spreadsheet.GetCell(0, 0).Value, Is.EqualTo("hello"));
    }
}