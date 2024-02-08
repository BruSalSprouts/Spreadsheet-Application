using System.IO;
using ReactiveUI;

namespace TextFileLoaderSaver.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public static string fibonacciNumbers()
    {
        return "";
    }
    public void LoadText(StreamReader textReader)
    {
        throw new System.NotImplementedException();
    }
}