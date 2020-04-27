using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static string RemoveExtraBlanks(string text)
        {
            text = text.Trim();
            return RemoveExtraBlanksAndTabs(text);
        }
        public static string RemoveExtraBlanksAndTabs(string line)
        {
            string newLine = "";
            bool blank = false;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ' && line[i] != '\t')
                {
                    newLine += line[i];
                    blank = true;
                }
                else if (blank)
                {
                    newLine += line[i];
                    blank = false;
                }
            }
            if (newLine.EndsWith(' ') || newLine.EndsWith('\t'))
            {
                newLine = newLine.Remove(newLine.Length - 1);
            }

            return newLine;
        }
        public static void ReadWrite(string inputFileName, string outputFileName)
        {
            StreamWriter outputFile = new StreamWriter(outputFileName);
            StreamReader inputFile = new StreamReader(inputFileName);
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                line = RemoveExtraBlanks(line);
                outputFile.WriteLine(line);
            }
            inputFile.Close();
            outputFile.Close();
        }
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Error!: Incorrect number of arguments! Need RemoveExtraBlanks.exe <input.txt> <output.txt>");
                return;
            }
            string inputFileName = args[0];
            string outputFileName = args[1];
            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Error!: Cannot open file for reading " + inputFileName);
                return;
            }
            ReadWrite(inputFileName, outputFileName);
        }
    }
}
