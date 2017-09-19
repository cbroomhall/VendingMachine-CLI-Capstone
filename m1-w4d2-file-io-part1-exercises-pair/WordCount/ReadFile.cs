using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class ReadFile
    {
        public static void ReadTextFile(string inputPath)
        {

            
            string fullPath = inputPath;
            int sentenceCount = 0;
            int wordCount = 0;
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadToEnd();

                        string[] words = line.Split(' ');
                        wordCount = words.Length;
                        string[] sentences = line.Split('.', '!', '?');
                        sentenceCount = sentences.Length;




                    }
                }
            }
            catch (IOException e) //catch a specific type of Exception
            {
                Console.WriteLine("Error reading the file");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("The number of words is " + wordCount);
            Console.WriteLine();
            Console.WriteLine("The number of sentences is " + sentenceCount);
            Console.ReadLine();
        }
    }
}




