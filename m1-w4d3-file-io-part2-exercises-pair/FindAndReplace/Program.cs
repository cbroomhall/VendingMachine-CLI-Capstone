using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindAndReplace
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your search phrase:");
            string inputSearch = Console.ReadLine();
            Console.WriteLine("Enter your replace phrase:");
            string inputReplace = Console.ReadLine();
            Console.WriteLine("Enter your source file path:");
            string inputInPath = Console.ReadLine();
            while (File.Exists(inputInPath)==false)
            {
                Console.WriteLine("Source file path invalid, try again:");
                inputInPath = Console.ReadLine();
            }
            Console.WriteLine("Enter your destination file path:");
            string inputOutPath = Console.ReadLine();

            FindAndReplace.InAndOut(inputSearch, inputReplace, inputInPath, inputOutPath);




        }
    }
}
