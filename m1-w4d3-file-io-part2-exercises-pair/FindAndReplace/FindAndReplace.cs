using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAndReplace
{
    public class FindAndReplace
    {
        public static void InAndOut(string inputSearch, string inputReplace, string inputInPath, string inputOutPath)
        {
            string inDirectory = inputInPath;
            string outDirectory = inputOutPath;
            string searchPhrase = inputSearch;
            string replacePhrase = inputReplace;




            if (File.Exists(inputOutPath))
            {
                Console.WriteLine();
                Console.WriteLine("This file/directory already exists");
                Console.ReadLine();
            }


            else
            {
                Directory.CreateDirectory(@"C:\Users\bespin\team2-c-week4-pair-exercises\m1-w4d3-file-io-part2-exercises-pair\AliceReplaced\");

                try
                {
                    using (StreamReader sr = new StreamReader(inDirectory))
                    {
                        using (StreamWriter sw = new StreamWriter(outDirectory, true))
                        {
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                string fixedLine = line.Replace(searchPhrase, replacePhrase);
                                sw.WriteLine(fixedLine);
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error reading the file");
                    Console.WriteLine(e.Message);
                }
            }
        }

    }

}

    



