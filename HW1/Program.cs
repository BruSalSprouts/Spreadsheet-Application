// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        GetIntList();
    }

    static void GetIntList()
    {
        Console.WriteLine("Write a list of integer numbers");
        string line = Console.ReadLine();
        Console.WriteLine("You wrote " + line);
    }
}