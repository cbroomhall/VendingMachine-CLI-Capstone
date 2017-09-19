using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please provide a filesystem path for your text file and press enter:");
            string inputPath = Console.ReadLine();

            ReadFile.ReadTextFile(inputPath);



        }
    }
}
