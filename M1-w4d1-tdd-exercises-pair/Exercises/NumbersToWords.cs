using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises
{
    public class NumbersToWords
    {



        public string NumsToWords(double amount)
        {
            int n = (int)amount;

            if (n == 0)
                return "zero";
            else if (n > 0 && n <= 19)
            {
                string[] arr = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                return arr[n - 1] + "";
            }
            else if (n >= 20 && n <= 99)
            {
                string[] arr = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                return arr[n / 10 - 2]  + "-" + NumsToWords(n % 10);
            }
            else if (n >= 100 && n <= 199)
            {
                return "one hundred " + NumsToWords(n % 100);
            }
            else if (n >= 200 && n <= 999)
            {
                return NumsToWords(n / 100) + " hundred " + "and " + NumsToWords(n % 100);
            }
            else if (n >= 1000 && n <= 1999)
            {
                return "one thousand " + NumsToWords(n % 1000);
            }
            else
            {
                return NumsToWords(n / 1000) + " thousand " + "and " + NumsToWords(n % 1000);

            }
        }
    }
}
