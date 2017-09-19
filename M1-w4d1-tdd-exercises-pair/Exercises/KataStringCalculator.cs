using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExercises
{
    public class KataStringCalculator
    {

        public int Add(string numbers)
        {

            if (numbers == "")
                return 0;
            int total = 0;

            if (numbers[0] == '/' && numbers[1] == '/')
            {
                //char otherChar = numbers[2];


                string[] newerStrings = numbers.Split(numbers[2]);
                //string[] finalString = new string[newerStrings.Length - 4];
                //finalString = newerStrings.Split()



                for (int i = 4; i < newerStrings.Length; i++)
                {
                    total += Convert.ToInt32(newerStrings[i]);

                }
               

            }

            else
            {
                string[] newStrings = numbers.Split(',', '\n', ';');

                for (int i = 0; i < newStrings.Length; i++)
                {
                    total += Convert.ToInt32(newStrings[i]);

                }
            }

            return total;

        }

    }
}
