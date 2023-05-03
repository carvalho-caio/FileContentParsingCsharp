using System;
using System.IO;
using System.Globalization;

namespace ExercicioFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\teste\exercicio.csv";
            string NewFile = @"c:\teste\exercicioResolvido.csv";

            try
            {
                string[] FileOriginalContent = File.ReadAllLines(path);

                using StreamWriter sw = File.AppendText(NewFile);
                {
                    foreach (string line in FileOriginalContent)
                    {
                        string[] SplitedFileContent = line.Split(",");

                        double Price = double.Parse(SplitedFileContent[1], CultureInfo.InvariantCulture.NumberFormat);
                        double Amount = double.Parse(SplitedFileContent[2]);
                        double NewPrice = Price * Amount;

                        sw.WriteLine($"{SplitedFileContent[0]},{NewPrice.ToString("F2", CultureInfo.InvariantCulture)}");
                        //Console.WriteLine($"{SplitedFileContent[0]},{NewPrice.ToString("F2", CultureInfo.InvariantCulture)}");
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred.");
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("format error");
            }
        }
    }
}