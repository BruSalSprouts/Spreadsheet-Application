using NUnit.Framework;
using FileLoaderSaver;
using FileLoaderSaver.ViewModels;
namespace HW3Testing;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFinishFilePath1()
    {
        string testFilePath = "test.txt";
        string finalFilePath = "C:\\Users\\bruno\\RiderProjects\\cpts321-hws\\FileLoaderSaver\\TextFiles\\test.txt";
        Assert.That(MainWindowViewModel.FinishFilePath(testFilePath), Is.EqualTo(finalFilePath));
    }
}