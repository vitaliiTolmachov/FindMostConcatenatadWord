using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntegrityVisionTest
{
    class Program
    {
        /// <summary>
        /// Reading words from file without empty spaces
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static IList<string> ReadData(string filePath)
        {
            return File.ReadAllLines(filePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Searching ...");

            var searchAlgorithm = new Tools();
            IList<string> inputData = null;
            try
            {
                inputData = ReadData("words.txt");
            }
            catch (Exception)
            {
                Console.Write("File words.txt not found in the current directory {0}", Directory.GetCurrentDirectory());
                Console.ReadKey();
                return;
            }

            var result = searchAlgorithm.Run(inputData);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Total TIME:{0} miliseconds\n", result.ResultTime.TotalMilliseconds.ToString("#.##"));
            Console.WriteLine("1. First word: {0}", result.ResultArray[0]);
            Console.WriteLine("2. Second word: {0}", result.ResultArray[1]);
            Console.WriteLine("3. Total count of concatenation words: {0}", result.ResultArray.Count);

            Console.ReadLine();
        }
    }
}
