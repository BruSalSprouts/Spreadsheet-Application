// See https://aka.ms/new-console-template for more information
// The purpose of this Console program is to understand how file saving and loading works

using System;
using System.IO;
using System.Text;

namespace TextReaderAndSaver;
class Program
{
    public static void Main()
    {
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        // string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFile.txt");
        // string filePath = "C:\\...\\TextReader\\TestFile.txt";
        //File paths
        string filePath1 = "TestFile.txt";
        string filePath2 = "TestSavedFile.txt";
        string filePath3 = "TestCreatedSaveFile.txt";
        Console.WriteLine($"Full path used: {FinishFilePath(filePath1)}");
        string contentToSave1 = "HIIII! Can someone give sentences that awe whatevew? (ʘᗩʘ')";
        string contentToSave2 = "UwU You knuw what? I'ww take da owoifed stuff ʕ•ᴥ•ʔ";
        // Console.ReadLine();
        
        SaveToFile(FinishFilePath(filePath2), contentToSave1);
        SaveToFile(FinishFilePath(filePath3), contentToSave2); //Text File did not previously exist, so it's created
        //Loads a file, and writes the string loaded from it to the Console
        Console.WriteLine(LoadFromFile(FinishFilePath(filePath3))); 
    }

    //Finishes the relative file path since absolute paths are the only one working for some reason
    private static string FinishFilePath(string filePathPiece)
    {
        //We use string builder that starts with the absolute path of the folder that contains the project
        StringBuilder newString = new StringBuilder("C:\\Users\\bruno\\RiderProjects\\cpts321-hws\\TextReaderAndSaver\\");
        newString.Append(filePathPiece); //We add the pathname that's the paramemter
        return newString.ToString(); //Return the completed file path
    }
    
    static void SaveToFile(string filePath, string content)
    {
        // Open the file with a TextWriter
        using (TextWriter writer = new StreamWriter(filePath))
        {
            // Write the content to the file
            writer.Write(content);
        }
        Console.WriteLine($"Content saved to {filePath}");
    }

    static string LoadFromFile(string filePath)
    {
        //Check if the file exists
        if (File.Exists(filePath))
        {
            //Open the file with a TextReader
            using (TextReader reader = File.OpenText(filePath))
            {
                // Read all the text from the file
                return reader.ReadToEnd();
            }
        }
        else
        {
            Console.WriteLine($"File not found: {filePath}");
            return String.Empty;
        }
    }
}