using System.IO;
using System.Numerics;
using System.Text;

namespace FileLoaderSaver.Models;

public class FibonacciTextReader : TextReader
{
    private int maxLines = 0;
    private int currentLines = 0;
    BigInteger currentNumber, nextNumber;
    /// <summary>
    /// Constructor for FibonacciTextReader, taking in the max number of lines to be read
    /// </summary>
    /// <param name="maxLines"></param>
    public FibonacciTextReader(int maxLines)
    {
        this.maxLines = maxLines;
        currentLines = 0;
        currentNumber = 0;
        nextNumber = 1;
    }
    /// <summary>
    /// Overrides ReadLine. Gets the next number in the sequence (the result), makes currentNumber the
    /// nextNumber and the nextNumber becomes the result, returns the result.
    /// </summary>
    /// <returns></returns>
    public override string? ReadLine()
    {
        if (currentLines >= maxLines) //Error handling
        {
            return null;
        }
        switch (currentLines) //Base cases
        {
            case 0: //Base case 0
                currentLines++;
                return "0";
            case 1: //Base case 1
                currentLines++;
                return "1";
        }

        BigInteger result = currentNumber + nextNumber;
        currentNumber = nextNumber;
        nextNumber = result;

        currentLines++;
        return result.ToString();
    }
    /// <summary>
    /// Overrides ReadToEnd. Calls ReadLine multiple times until the end of file is reached, putting each line
    /// retrieved into string resultBuilder. Returns resultBuilder as a string
    /// The main function to be called to read files
    /// </summary>
    /// <returns></returns>
    public override string ReadToEnd()
    {
        StringBuilder resultBuilder = new StringBuilder();
        int currentIteration = 1;
        string? line; // In case we return null from the error handling
        while ((line = ReadLine()) != null)
        {
            resultBuilder.AppendLine(currentIteration + ": " + line); //Adds the line
            currentIteration++;
        }

        return resultBuilder.ToString();
    }
}