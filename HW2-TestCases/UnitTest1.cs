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
    public void Test1()
    {
        //Hash method Tests
        List<int> testList = new List<int>();
        testList.Add(1);
        Assert.Zero(MainWindowViewModel.hashMethod(testList));

        //O(1) method Tests


        //Sorting method Tests
    }
}