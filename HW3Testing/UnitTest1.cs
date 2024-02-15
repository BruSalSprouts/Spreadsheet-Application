using NUnit.Framework;
using FileLoaderSaver;
using FileLoaderSaver.ViewModels;
using FileLoaderSaver.Models;
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
    [Test]
    public void TestFibString1()
    {
        FibonacciTextReader fib1 = new FibonacciTextReader(1);
        string test = fib1.ReadToEnd();
        Assert.That(test, Is.EqualTo("0\r\n"));
    }
    [Test]
    public void TestFibString2()
    {
        FibonacciTextReader fib1 = new FibonacciTextReader(2);
        string test = fib1.ReadToEnd();
        Assert.That(test, Is.EqualTo("0\r\n1\r\n"));
    }
    [Test]
    public void TestFibString3()
    {
        FibonacciTextReader fib1 = new FibonacciTextReader(3);
        string test = fib1.ReadToEnd();
        Assert.That(test, Is.EqualTo("0\r\n1\r\n1\r\n"));
    }
    [Test]
    public void TestFibString4()
    {
        FibonacciTextReader fib1 = new FibonacciTextReader(5);
        string test = fib1.ReadToEnd();
        Assert.That(test, Is.EqualTo("0\r\n1\r\n1\r\n2\r\n3\r\n"));
    }
}