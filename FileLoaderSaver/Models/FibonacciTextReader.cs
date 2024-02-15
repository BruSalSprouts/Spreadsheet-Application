using System.IO;

namespace FileLoaderSaver.Models;

public class FibonacciTextReader : TextReader
{
    private int maxLines = 0;
    FibonacciTextReader(int maxLines)
    {
        this.maxLines = maxLines;
    }
}