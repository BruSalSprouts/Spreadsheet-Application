using DynamicData;
using NUnit.Framework.Interfaces;

namespace HW2_TestCases;
using NUnit.Framework;
using HW2_DistinctIntegers.ViewModels;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestHashMap1()
    {
        //Hash method Tests
        List<int> testList = new List<int>(); // Has only 1 element
        testList.Add(21);
        Assert.That(MainWindowViewModel.HashMethod(testList), Is.EqualTo(1));
    }
    [Test]
    public void TestHashMap2()
    {
        List<int> testList = new List<int>(); // Has 5 elements (1 - 5)
        for (int i = 1; i <= 5; i++)
        {
            testList.Add(i + 1);
        }
        Assert.That(MainWindowViewModel.HashMethod(testList), Is.EqualTo(5));
    }
    [Test]
    public void TestHashMap3()
    {
        List<int> testList = new List<int>(); // Has 100 elements (1 - 100)
        for (int i = 1; i <= 100; i++)
        {
            testList.Add(i);
        }
        Assert.That(MainWindowViewModel.HashMethod(testList), Is.EqualTo(100));
    }
    [Test]
    public void TestHashMap4()
    {
        List<int> testList = new List<int>(); // Has 5 elements that are all the same number, 2
        for (int i = 1; i <= 5; i++)
        {
            testList.Add(2);
        }
        Assert.That(MainWindowViewModel.HashMethod(testList), Is.EqualTo(1));
    }
    [Test]
    public void TestHashMap5()
    {
        List<int> testList = new List<int>(); // Has 10 elements (1 - 9), and 2 duplicates
        for (int i = 1; i <= 9; i++)
        {
            testList.Add(i);
        }
        testList.Add(5);
        Assert.That(MainWindowViewModel.HashMethod(testList), Is.EqualTo(9));
    }
    [Test]
    public void TestOMet1()
    {
        //Hash method Tests
        List<int> testList = new List<int>(); // Has only 1 element
        testList.Add(21);
        Assert.That(MainWindowViewModel.OOneMethod(testList), Is.EqualTo(1));
    }
    [Test]
    public void TestOMet2()
    {
        List<int> testList = new List<int>(); // Has 5 elements (1 - 5)
        for (int i = 1; i <= 5; i++)
        {
            testList.Add(i + 1);
        }
        Assert.That(MainWindowViewModel.OOneMethod(testList), Is.EqualTo(5));
    }
    [Test]
    public void TestOMet3()
    {
        List<int> testList = new List<int>(); // Has 100 elements (1 - 100)
        for (int i = 1; i <= 100; i++)
        {
            testList.Add(i);
        }
        Assert.That(MainWindowViewModel.OOneMethod(testList), Is.EqualTo(100));
    }
    [Test]
    public void TestOMet4()
    {
        List<int> testList = new List<int>(); // Has 5 elements that are all the same number, 2
        for (int i = 1; i <= 5; i++)
        {
            testList.Add(2);
        }
        Assert.That(MainWindowViewModel.OOneMethod(testList), Is.EqualTo(1));
    }
    [Test]
    public void TestOMet5()
    {
        List<int> testList = new List<int>(); // Has 10 elements (1 - 9), and 2 duplicates
        for (int i = 1; i <= 9; i++)
        {
            testList.Add(i);
        }
        testList.Add(5);
        Assert.That(MainWindowViewModel.OOneMethod(testList), Is.EqualTo(9));
    }
    [Test]
    public void TestSort1()
    {
        //Hash method Tests
        List<int> testList = new List<int>(); // Has only 1 element
        testList.Add(21);
        Assert.That(MainWindowViewModel.SortingMethod(testList), Is.EqualTo(1));
    }
    [Test]
    public void TestSort2()
    {
        List<int> testList = new List<int>(); // Has 5 elements (1 - 5)
        for (int i = 1; i <= 5; i++)
        {
            testList.Add(i + 1);
        }
        Assert.That(MainWindowViewModel.SortingMethod(testList), Is.EqualTo(5));
    }
    [Test]
    public void TestSort3()
    {
        List<int> testList = new List<int>(); // Has 100 elements (1 - 100)
        for (int i = 1; i <= 100; i++)
        {
            testList.Add(i);
        }
        Assert.That(MainWindowViewModel.SortingMethod(testList), Is.EqualTo(100));
    }
    [Test]
    public void TestSort4()
    {
        List<int> testList = new List<int>(); // Has 5 elements that are all the same number, 2
        for (int i = 1; i <= 5; i++)
        {
            testList.Add(2);
        }
        Assert.That(MainWindowViewModel.SortingMethod(testList), Is.EqualTo(1));
    }
    [Test]
    public void TestSort5()
    {
        List<int> testList = new List<int>(); // Has 10 elements (1 - 9), and 2 duplicates
        for (int i = 1; i <= 9; i++)
        {
            testList.Add(i);
        }
        testList.Add(5);
        Assert.That(MainWindowViewModel.SortingMethod(testList), Is.EqualTo(9));
    }
}